param(
    [Parameter(Mandatory=$true)]
    [string]$LogFilePath,
    [Parameter(Mandatory=$true)]
    [string]$OutputFilePath
)

# Читаем лог сборки
$logContent = Get-Content -Path $LogFilePath -Raw

# Шаблон регулярного выражения для выделения предупреждений
$regex = '^(?<File>.+?):\s+(?<Severity>\w+)\s+(?<Code>\w+\s\d+)\:\s+(?<Message>.+)($$\S+$$)?$'

# Парсим лог и получаем коллекцию предупреждений
$warnings = Select-String -Pattern $regex -InputObject $logContent -AllMatches |
    ForEach-Object {
        $_ | Select-Object -Expand Matches |
        ForEach-Object {
            @{
                File = ($_ -replace "^.*\\ExpeditionPlanner\\", "") -replace "$([^)]+)$", '$1'
                Severity = $_.Groups['Severity'].Value
                Code = $_.Groups['Code'].Value
                Message = $_.Groups['Message'].Value.Trim() -replace "^$([^)]+)$", '$1'
            }
        }
    }

# Сортируем по коду ошибки
$sortedWarnings = $warnings | Sort-Object -Property Code

# Генерируем текстовую таблицу
$table = $sortedWarnings | ForEach-Object -Begin {$i=1} -Process {
    "{0,-4}{1,-50}{2,-10}{3,-10}{4}" -f $i++,$_.File,$_.Severity,"$($_.Code)",$_.Message
}

# Сохраняем таблицу в выходной файл
$table | Out-File -FilePath $OutputFilePath -Encoding UTF8