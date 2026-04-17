param(
    [Parameter(Mandatory=$true)]
    [string]$LogFilePath,
    [Parameter(Mandatory=$true)]
    [string]$OutputFilePath
)

$logContent = Get-Content -Path $LogFilePath -Raw
$regex = '(.*):\s*(warning\s\w+)\:\s*(.*)'
$matches = Select-String -Pattern $regex -InputObject $logContent -AllMatches
$warnings = @($matches.Matches | ForEach-Object {
    @{
        File = $_.Groups[1].Value
        Code = $_.Groups[2].Value
        Message = $_.Groups[3].Value
    }
})
$warnings | ConvertTo-Json | Out-File -FilePath $OutputFilePath