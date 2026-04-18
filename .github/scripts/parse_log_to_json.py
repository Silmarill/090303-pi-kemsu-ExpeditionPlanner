import re
import json
import argparse

def extract_url(text):
    match = re.search(r'https?://\S+', text)
    if match:
        url = match.group(0)
        if url.endswith(')'):
            url = url[:-1]
        return url
    return None

def parse_build_log_to_json(input_path, output_json):
    with open(input_path, 'r', encoding='utf-8') as f:
        lines = f.readlines()

    # Основной паттерн (для SA и IDE с координатами)
    pattern = r'^(.+?)\((\d+),(\d+)\):\s+(warning|error)\s+([A-Za-z0-9]+):\s+(.*?)(?:\s+\[.*\])?$'
    # Альтернативный паттерн (без координат)
    alt_pattern = r'^(\S+)\s+:\s+(warning|error)\s+(\S+):\s+(.*)$'
    # Явный паттерн для IDE (на всякий случай)
    ide_pattern = r'^(.+?)\((\d+),(\d+)\):\s+(warning|error)\s+(IDE\d+):\s+(.*)$'

    unique_warnings = {}

    for line in lines:
        line = line.strip()
        if not line:
            continue

        # Сначала пробуем основной паттерн
        match = re.match(pattern, line)
        if not match:
            # Потом IDE-паттерн (он более специфичен, но по сути совпадает с основным)
            match = re.match(ide_pattern, line)
        if not match:
            # Потом альтернативный
            match = re.match(alt_pattern, line)

        if match:
            if match.re.pattern == alt_pattern.pattern:
                # альтернативный формат
                source = match.group(1)
                severity = match.group(2)
                code = match.group(3)
                message = match.group(4).strip()
                url = extract_url(message)
                key = (source, None, None, code)
                if key not in unique_warnings:
                    unique_warnings[key] = {
                        "full_path": source,
                        "line": None,
                        "column": None,
                        "severity": severity,
                        "code": code,
                        "message": message,
                        "url": url,
                        "raw_line": line
                    }
            else:
                # основной или IDE-паттерн (с координатами)
                full_path = match.group(1)
                line_num = int(match.group(2))
                col_num = int(match.group(3))
                severity = match.group(4)
                code = match.group(5)
                message = match.group(6).strip()
                url = extract_url(message)
                key = (full_path, line_num, col_num, code)
                if key not in unique_warnings:
                    unique_warnings[key] = {
                        "full_path": full_path,
                        "line": line_num,
                        "column": col_num,
                        "severity": severity,
                        "code": code,
                        "message": message,
                        "url": url,
                        "raw_line": line
                    }
        # Если ни один паттерн не подошёл, строка игнорируется

    warnings_list = list(unique_warnings.values())
    with open(output_json, 'w', encoding='utf-8') as f:
        json.dump(warnings_list, f, indent=2, ensure_ascii=False)

    print(f"JSON saved to {output_json} (unique warnings: {len(warnings_list)})")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--log-file", required=True)
    parser.add_argument("--output-json", required=True)
    args = parser.parse_args()
    parse_build_log_to_json(args.log_file, args.output_json)