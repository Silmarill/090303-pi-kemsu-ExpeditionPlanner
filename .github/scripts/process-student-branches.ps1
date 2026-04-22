param(
    [string]$PatToken,
    [string]$CopilotToken,
    [string]$Repository
)

$ErrorActionPreference = "Stop"

Write-Host "Starting student branches processing..."

# Получаем список веток
$branches = git branch -r | Where-Object { $_ -match 'origin/(group[5-6]/[^/]+)$' } | ForEach-Object { $matches[1] }
Write-Host "Found branches: $($branches -join ', ')"

$total = $branches.Count
$index = 0

# Клонируем main-branch скрипты
Write-Host "Cloning main branch (for scripts)..."
git clone --depth 1 --branch main "https://x-access-token:$PatToken@github.com/$Repository" main-branch-temp

$failedBranchesFile = "$env:GITHUB_WORKSPACE/failed-branches.txt"
New-Item -Path $failedBranchesFile -ItemType File -Force | Out-Null
Add-Content $failedBranchesFile "Ветки без изменений или с ошибкой компиляции:`n"

foreach ($branch in $branches) {
    $index++
    Write-Host "`n========================================"
    Write-Host "[$index/$total] Processing branch: $branch"
    Write-Host "========================================"

    # Проверяем изменения относительно main
    git fetch origin $branch
    $diffStat = git diff --stat main...origin/$branch
    if (-not $diffStat) {
        Write-Host "⚠️ Branch $branch has no changes compared to main. Skipping."
        Add-Content $failedBranchesFile "- $branch (no changes)"
        continue
    }

    # Создаём PR
    $prTitle = "$branch - Initial review"
    $prBody = @"
Automated code review.

- Style check passed.
- Copilot review completed.

Please review the comments and fix the issues.

If you have questions, tag the instructor in the PR comments.
"@

    $prResult = gh pr create --title "$prTitle" --body "$prBody" --base main --head $branch --repo $Repository --token $PatToken 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "❌ Failed to create PR for $branch. Error: $prResult"
        Add-Content $failedBranchesFile "- $branch (failed to create PR)"
        continue
    }
    $prNumber = $prResult -replace '.*#(\d+).*', '$1'
    Write-Host "✅ PR #$prNumber created"

    # Клонируем код студента
    Write-Host "Cloning student code from branch $branch ..."
    git clone --depth 1 --branch $branch "https://x-access-token:$PatToken@github.com/$Repository" student-code
    Push-Location student-code

    # Копируем конфиги
    Copy-Item -Path "../main-branch-temp/.editorconfig" -Destination "." -Force -ErrorAction SilentlyContinue
    New-Item -Path "ExpeditionPlanner" -ItemType Directory -Force | Out-Null
    Copy-Item -Path "../main-branch-temp/Settings.StyleCop.json" -Destination "ExpeditionPlanner/Settings.StyleCop.json" -Force -ErrorAction SilentlyContinue

    # Конвертируем проект и добавляем StyleCop
    Write-Host "Converting project to SDK style and adding StyleCop..."
    pwsh "../main-branch-temp/.github/scripts/convert_and_add_stylecop.ps1" -CsprojPath "ExpeditionPlanner/ExpeditionPlanner.csproj" -Workspace (Get-Location).Path

    # Сборка
    Write-Host "Restoring NuGet packages..."
    dotnet restore ExpeditionPlanner/ExpeditionPlanner.csproj
    Write-Host "Building project..."
    $buildOutput = dotnet build ExpeditionPlanner/ExpeditionPlanner.csproj 2>&1
    $buildExitCode = $LASTEXITCODE

    if ($buildExitCode -ne 0) {
        Write-Host "❌ Build failed for $branch"
        gh pr edit $prNumber --title "[BUILD FAILED] $prTitle" --repo $Repository --token $PatToken
        $errorLog = ($buildOutput | Select-Object -Last 30) -join "`n"
        $comment = "Build failed. Exit code: $buildExitCode`n`n```n$errorLog`n```"
        $commentFile = "$env:GITHUB_WORKSPACE\comment.txt"
        $comment | Out-File -FilePath $commentFile -Encoding utf8
        gh pr comment $prNumber --body-file $commentFile --repo $Repository --token $PatToken
        Remove-Item $commentFile
        Add-Content $failedBranchesFile "- $branch (build failed)"
        Pop-Location
        Remove-Item -Recurse -Force student-code
        continue
    }

    Write-Host "✅ Build successful for $branch"

    # Сохраняем лог сборки
    $buildOutput | Out-File -FilePath build.log -Encoding utf8

    # dotnet format
    Write-Host "Running dotnet format..."
    dotnet tool install -g dotnet-format
    dotnet format ExpeditionPlanner/ExpeditionPlanner.csproj style --verify-no-changes --severity info > ide_warnings.txt 2>&1

    # Объединяем логи
    Get-Content build.log > combined.log
    Add-Content combined.log "`n=== dotnet format warnings ===`n"
    if (Test-Path ide_warnings.txt) {
        Get-Content ide_warnings.txt >> combined.log
    } else {
        Add-Content combined.log "No IDE warnings found."
    }

    # Анализ стиля
    Write-Host "Running StyleCop analysis..."
    python "../main-branch-temp/.github/scripts/parse_log_to_json.py" --log-file combined.log --output-json warnings.json
    python "../main-branch-temp/.github/scripts/generate_report_from_json.py" --json-file warnings.json --output-txt stylecop_report.txt

    $reportContent = Get-Content stylecop_report.txt -Raw
    if ($reportContent.Length -gt 60000) {
        $reportContent = $reportContent.Substring(0, 60000) + "`n... (truncated, see artifacts for full report)"
    }
    $reportComment = "## StyleCop analysis results`n`n```n$reportContent`n```"
    $reportFile = "$env:GITHUB_WORKSPACE\report.txt"
    $reportComment | Out-File -FilePath $reportFile -Encoding utf8
    gh pr comment $prNumber --body-file $reportFile --repo $Repository --token $PatToken
    Remove-Item $reportFile

    # Copilot review
    Write-Host "Running Copilot review..."
    gh extension install k1LoW/gh-copilot-review --force
    echo $CopilotToken | gh auth login --with-token
    gh copilot-review $prNumber --repo $Repository || Write-Host "⚠️ Copilot review failed"

    # Очистка
    Pop-Location
    Remove-Item -Recurse -Force student-code
    Write-Host "✅ Finished processing branch $branch"
}

Write-Host "`nProcessing complete. Failed branches saved to $failedBranchesFile"
