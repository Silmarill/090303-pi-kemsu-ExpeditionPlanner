import re
from collections import defaultdict

def parse_build_log(input_path, output_path):
    # Читаем лог сборки
    with open(input_path, 'r', encoding='utf-8') as f:
        log_content = f.read()

    # Шаблон регулярного выражения для выделения предупреждений
    regex = r'^(?P<File>.+?):\s+(?P<Severity>\w+)\s+(?P<Code>\w+\s\d+)\:\s+(?P<Message>.+)(?:$$\S+$$)?$'

    # Парсим лог и получаем коллекцию предупреждений
    warnings = []
    for line in log_content.splitlines():
        match = re.match(regex, line.strip())
        if match:
            file_part = match.group('File')
            severity = match.group('Severity')
            code = match.group('Code')
            message = match.group('Message').strip().split('(', 1)[0].strip()
            
            # Обрезаем путь к файлу до относительного вида
            relative_file = file_part.replace('\\ExpeditionPlanner\\', '', 1)
            parts = relative_file.rsplit('(', 1)
            if len(parts) == 2:
                file_name, coordinates = parts
                coordinates = coordinates.strip(')')
                file_with_coords = f"{file_name}({coordinates})"
            else:
                file_with_coords = relative_file
                
            warnings.append({
                'File': file_with_coords,
                'Severity': severity,
                'Code': code,
                'Message': message
            })

    # Сортируем по коду ошибки
    sorted_warnings = sorted(warnings, key=lambda w: w['Code'])

    # Генерируем текстовую таблицу
    table_lines = []
    for idx, warn in enumerate(sorted_warnings, start=1):
        table_line = f"{idx:<4}{warn['File']:<50}{warn['Severity']:<10}{warn['Code']:<10}{warn['Message']}"
        table_lines.append(table_line)

    # Сохраняем таблицу в выходной файл
    with open(output_path, 'w', encoding='utf-8') as out_f:
        out_f.write('\n'.join(table_lines))

# Пример использования
input_path = 'build.log'
output_path = 'stylecop_report.txt'
parse_build_log(input_path, output_path)
print(f"Отчёт успешно сохранён в файл '{output_path}'")