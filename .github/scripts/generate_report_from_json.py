import json
import argparse
from collections import defaultdict

def truncate_path(path, max_len=50):
    """Обрезает путь до последних max_len символов, добавляя '...' спереди."""
    if len(path) <= max_len:
        return path
    return "..." + path[-(max_len-3):]

def generate_report(json_path, output_txt):
    with open(json_path, 'r', encoding='utf-8') as f:
        warnings = json.load(f)

    # Группировка по коду ошибки
    groups = defaultdict(list)
    for w in warnings:
        groups[w["code"]].append(w)

    # Сортировка кодов (алфавитно)
    lines = []
    for code in sorted(groups.keys()):
        items = groups[code]
        # Берём первое сообщение и URL для этого кода (они обычно одинаковые)
        first = items[0]
        message = first["message"]
        url = first.get("url", "")

        # Отделяем описание от URL в message (если URL есть в message, убираем его для чистоты)
        if url and url in message:
            desc = message.replace(f" ({url})", "").replace(f" {url}", "").strip()
        else:
            desc = message

        # Заголовок раздела
        lines.append(f"{code} {desc}")
        if url:
            lines.append(f"URL: {url}")
        lines.append("")  # пустая строка

        # Заголовок таблицы
        lines.append(f"{'#':<4} {'File':<50} {'Line':<6} {'Column'}")
        lines.append("-" * 70)

        # Сортировка внутри группы: по полному пути, потом по строке/столбцу
        sorted_items = sorted(items, key=lambda x: (x["full_path"], x["line"] or 0, x["column"] or 0))

        for idx, w in enumerate(sorted_items, start=1):
            # Формируем отображаемый путь: полный путь + (строка,столбец)
            display_path = w["full_path"]
            if w["line"] is not None and w["column"] is not None:
                display_path += f"({w['line']},{w['column']})"
            # Обрезаем путь до 50 символов
            short_path = truncate_path(display_path, 50)

            line_str = str(w["line"]) if w["line"] is not None else ""
            col_str = str(w["column"]) if w["column"] is not None else ""

            lines.append(f"{idx:<4} {short_path:<50} {line_str:<6} {col_str}")

        lines.append("")  # пустая строка между разделами

    with open(output_txt, 'w', encoding='utf-8') as f:
        f.write("\n".join(lines))

    print(f"Report saved to {output_txt}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--json-file", required=True)
    parser.add_argument("--output-txt", required=True)    
    args = parser.parse_args()
    generate_report(args.json_file, args.output_txt)