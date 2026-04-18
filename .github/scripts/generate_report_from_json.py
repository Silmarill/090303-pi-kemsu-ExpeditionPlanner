import json
import argparse

def generate_report(json_path, output_txt, repo_root):
    with open(json_path, 'r', encoding='utf-8') as f:
        warnings = json.load(f)

    # Сортировка: по коду, затем по полному пути
    sorted_warnings = sorted(warnings, key=lambda x: (x["code"], x["full_path"]))

    lines = []
    lines.append(f"{'#':<4} {'File':<50} {'Code':<12} {'Message'}")
    lines.append("-" * 90)

    for idx, w in enumerate(sorted_warnings, start=1):
        file_display = w["full_path"]
        if w["line"] and w["column"]:
            file_display += f"({w['line']},{w['column']})"
        # Обрезаем до последних 50 символов (добавляем "...")
        if len(file_display) > 50:
            file_display = "..." + file_display[-47:]
        file_part = file_display.ljust(50)
        code_part = w["code"].ljust(12)
        message = w["message"]   # полное сообщение (включая URL)
        lines.append(f"{idx:<4} {file_part} {code_part} {message}")

    with open(output_txt, 'w', encoding='utf-8') as f:
        f.write("\n".join(lines))

    print(f"Report saved to {output_txt}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--json-file", required=True)
    parser.add_argument("--output-txt", required=True)
    parser.add_argument("--repo-root", required=True)
    args = parser.parse_args()
    generate_report(args.json_file, args.output_txt, args.repo_root)