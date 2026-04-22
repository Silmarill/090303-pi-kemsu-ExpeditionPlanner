param(
    [string]$PatToken,
    [string]$CopilotToken,
    [string]$Repository
)

$ErrorActionPreference = "Stop"

# Получаем список веток (можно передать как параметр или вычислить здесь)
$branches = git branch -r | Where-Object { $_ -match 'origin/(group[5-6]/[^/]+)$' } | ForEach-Object { $matches[1] }
$total = $branches.Count
$index = 0

# Клонируем main-branch скрипты (уже должны быть склонированы в workflow, но на всякий случай)
if (-not (Test-Path "main-branch-temp")) {
    git clone --depth 1 --branch main https://x-access-token:$PatToken@github.com/$Repository main-branch-temp
}

foreach ($branch in $branches) {
    $index++
    Write-Host "`n========================================"
    Write-Host "[$index/$total] Обработка ветки: $branch"
    Write-Host "========================================"

    # Проверка изменений
    git fetch origin $branch
    $diffStat = git diff --stat main...origin/$branch
    if (-not $diffStat) {
        Write-Host "⚠️ Ветка $branch не содержит изменений относительно main. Пропускаем."
        Add-Content "$env:GITHUB_WORKSPACE/failed-branches.txt" "- $branch (нет изменений)"
        continue
    }

    # Создание PR
    $prTitle = "$branch - Первичная проверка"
    $prBody = @"
Проведена первичная проверка стиля.
Проведено первичное ИИ ревью.
Внимательно изучите и внесите изменения.

Если будут вопросы:
1) Находите замечания, с которым не согласны (или есть сомнение/непонимание почему так).
2) Тегаете преподавателя под замечанием через @ и пишете вопрос в комментарии.
3) Скидываете ссылку на комментарий в чатик (можно сопроводить ссылку текстом) - преподаватель возьмет в работу.

Пожелание: делать изменения за один пуш-коммит - так удобнее проверять, что вы не проигнорировали ревью.
"@

    $prNumber = gh pr create --title "$prTitle" --body "$prBody" --base main --head $branch --repo $Repository --token $PatToken 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "❌ Не удалось создать PR для $branch. Ошибка: $prNumber"
        Add-Content "$env:GITHUB_WORKSPACE/failed-branches.txt" "- $branch (не удалось создать PR)"
        continue
    }
    $prNumber = $prNumber -replace '.*#(\d+).*', '$1'
    Write-Host "✅ PR #$prNumber создан"

    # Клонируем код студента
    git clone --depth 1 --branch $branch https://x-access-token:$PatToken@github.com/$Repository student-code
    Push-Location student-code

    # Копируем конфиги
    Copy-Item -Path "../main-branch-temp/.editorconfig" -Destination "." -Force -ErrorAction SilentlyContinue
    New-Item -Path "ExpeditionPlanner" -ItemType Directory -Force
    Copy-Item -Path "../main-branch-temp/Settings.StyleCop.json" -Destination "ExpeditionPlanner/Settings.StyleCop.json" -Force -ErrorAction SilentlyContinue

    # Конвертация проекта
    pwsh "../main-branch-temp/.github/scripts/convert_and_add_stylecop.ps1" -CsprojPath "ExpeditionPlanner/ExpeditionPlanner.csproj" -Workspace (Get-Location).Path

    # Восстановление и сборка
    dotnet restore ExpeditionPlanner/ExpeditionPlanner.csproj
    $buildOutput = dotnet build ExpeditionPlanner/ExpeditionPlanner.csproj 2>&1
    $buildExitCode = $LASTEXITCODE

    if ($buildExitCode -ne 0) {
        Write-Host "❌ Сборка не удалась для $branch"
        gh pr edit $prNumber --title "[НЕ КОМПИЛИРУЕТСЯ] $prTitle" --repo $Repository --token $PatToken
        $errorLog = ($buildOutput | Select-Object -Last 30) -join "`n"
        $comment = "Сборка завершилась с ошибкой. Код: $buildExitCode`n`n```n$errorLog`n```"
        $comment | Out-File -FilePath "$env:GITHUB_WORKSPACE/comment.txt" -Encoding utf8
        gh pr comment $prNumber --body-file "$env:GITHUB_WORKSPACE/comment.txt" --repo $Repository --token $PatToken
        Remove-Item "$env:GITHUB_WORKSPACE/comment.txt"
        Add-Content "$env:GITHUB_WORKSPACE/failed-branches.txt" "- $branch (ошибка компиляции)"
        Pop-Location
        Remove-Item -Recurse -Force student-code
        continue
    }

    Write-Host "✅ Сборка успешна для $branch"

    # Сохраняем лог сборки
    $buildOutput | Out-File -FilePath build.log -Encoding utf8

    # dotnet format
    dotnet tool install -g dotnet-format
    dotnet format ExpeditionPlanner/ExpeditionPlanner.csproj style --verify-no-changes --severity info > ide_warnings.txt 2>&1

    # Объединение логов
    Get-Content build.log > combined.log
    Add-Content combined.log "`n=== Предупреждения dotnet format ===`n"
    if (Test-Path ide_warnings.txt) {
        Get-Content ide_warnings.txt >> combined.log
    } else {
        Add-Content combined.log "Файл с предупреждениями IDE не найден."
    }

    # Отчёты
    python "../main-branch-temp/.github/scripts/parse_log_to_json.py" --log-file combined.log --output-json warnings.json
    python "../main-branch-temp/.github/scripts/generate_report_from_json.py" --json-file warnings.json --output-txt stylecop_report.txt

    $reportContent = Get-Content stylecop_report.txt -Raw
    if ($reportContent.Length -gt 60000) {
        $reportContent = $reportContent.Substring(0, 60000) + "`n... (отчёт обрезан, полный в артефактах)"
    }
    $reportComment = "## Результаты статического анализа`n`n```n$reportContent`n```"
    $reportComment | Out-File -FilePath "$env:GITHUB_WORKSPACE/report.txt" -Encoding utf8
    gh pr comment $prNumber --body-file "$env:GITHUB_WORKSPACE/report.txt" --repo $Repository --token $PatToken
    Remove-Item "$env:GITHUB_WORKSPACE/report.txt"

    # Copilot review
    gh extension install k1LoW/gh-copilot-review --force
    echo $CopilotToken | gh auth login --with-token
    gh copilot-review $prNumber --repo $Repository || Write-Host "⚠️ Copilot review не удался"

    # Очистка
    Pop-Location
    Remove-Item -Recurse -Force student-code
    Write-Host "✅ Обработка ветки $branch завершена"
}

Write-Host "`nСписок проблемных веток сохранён в failed-branches.txt"