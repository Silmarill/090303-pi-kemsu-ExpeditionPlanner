param(
    [Parameter(Mandatory=$true)]
    [string]$LogFilePath,
    [Parameter(Mandatory=$true)]
    [string]$OutputFilePath
)

# Читаем лог сборки
$logContent = Get-Content -Path $LogFilePath -Raw

# Шаблон регулярного выражения для выделения предупреждений
$regex = '(.*):\s*(warning\s\w+)\:\s*(.*)'

# Парсим лог и получаем коллекцию предупреждений
$warnings = Select-String -Pattern $regex -InputObject $logContent -AllMatches |
    ForEach-Object {
        $_ | Select-Object -Expand Matches |
        ForEach-Object {
            @{
                File = ($_.Groups[1].Value -split '\\')[2..($_.Groups[1].Value.Split('\').Count - 1)] -join '\';
                Code = $_.Groups[2].Value;
                Message = $_.Groups[3].Value.Trim()
            }
        }
    }

# Сортируем по коду ошибки
$sortedWarnings = $warnings | Sort-Object -Property Code

# Генерируем текстовую таблицу
$table = $sortedWarnings | ForEach-Object -Begin {$i=1} -Process {
    "{0,-4}{1,-50}{2,-10}{3}" -f $i++,$_.File,$_.Code,$_.Message
}

# Сохраняем таблицу в выходной файл
$table | Out-File -FilePath $OutputFilePath -Encoding UTF8