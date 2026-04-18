import json
import argparse
from pathlib import Path

def generate_report(json_path, output_txt, repo_root):
    with open(json_path, 'r', encoding='utf-8') as f:
        warnings = json.load(f)

    # Добавляем относительный путь для каждого предупреждения
    for w in warnings:
        full = w["full_path"]
        # Обрезаем до части после "ExpeditionPlanner\"
        if "ExpeditionPlanner\\" in full:
            rel = full.split("ExpeditionPlanner\\", 1)[1]
        else:
            rel = full
        w["relative_path"] = rel

    # Сортировка: сначала по коду, затем по относительному пути
    sorted_warnings = sorted(warnings, key=lambda x: (x["code"], x["relative_path"]))

    # Формируем таблицу
    lines = []
    lines.append(f"{'#':<4} {'File':<60} {'Code':<12} {'Message'}")
    lines.append("-" * 90)
    for idx, w in enumerate(sorted_warnings, start=1):
        file_display = w["relative_path"]
        if w["line"] and w["column"]:
            file_display += f"({w['line']},{w['column']})"
        # Ограничиваем длину для читаемости
        file_part = (file_display[:57] + '...') if len(file_display) > 60 else file_display.ljust(60)
        code_part = w["code"].ljust(12)
        message_part = w["message"][:80]  # обрезаем длинные сообщения
        lines.append(f"{idx:<4} {file_part} {code_part} {message_part}")

    with open(output_txt, 'w', encoding='utf-8') as f:
        f.write("\n".join(lines))

    print(f"Report saved to {output_txt}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--json-file", required=True)
    parser.add_argument("--output-txt", required=True)
    parser.add_argument("--repo-root", required=True, help="Корень репозитория для вычисления относительных путей")
    args = parser.parse_args()
    generate_report(args.json_file, args.output_txt, args.repo_root)