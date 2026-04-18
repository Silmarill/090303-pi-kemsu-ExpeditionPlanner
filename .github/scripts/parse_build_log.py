import re
import argparse
import sys

def parse_build_log(input_path, output_path):
    # Читаем лог сборки (UTF-8)
    with open(input_path, 'r', encoding='utf-8') as f:
        log_content = f.read()

    # Шаблон регулярного выражения для выделения предупреждений
    regex = r'^(?P<File>.+?):\s+(?P<Severity>\w+)\s+(?P<Code>\w+\s\d+)\:\s+(?P<Message>.+)(?:$$\S+$$)?$'

    warnings = []
    for line in log_content.splitlines():
        match = re.match(regex, line.strip())
        if match:
            file_part = match.group('File')
            severity = match.group('Severity')
            code = match.group('Code')
            message = match.group('Message').strip().split('(', 1)[0].strip()

            # Обрезаем путь до относительного
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

    # Сортируем
    sorted_warnings = sorted(warnings, key=lambda w: w['Code'])

    # Формируем таблицу
    table_lines = []
    for idx, warn in enumerate(sorted_warnings, start=1):
        table_line = f"{idx:<4}{warn['File']:<50}{warn['Severity']:<10}{warn['Code']:<10}{warn['Message']}"
        table_lines.append(table_line)

    # Записываем результат (UTF-8)
    with open(output_path, 'w', encoding='utf-8') as out_f:
        out_f.write('\n'.join(table_lines))

    # Вывод сообщения об успехе (без русских символов для Windows)
    print(f"Report saved to {output_path}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--log-file", required=True, help="Path to build.log")
    parser.add_argument("--output-file", required=True, help="Path for report output")
    args = parser.parse_args()

    parse_build_log(args.log_file, args.output_file)