using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private int _missionDurationDays = 20;
    private int _agreementsCount = 3;

    public DiplomaticMission() {
      // инициализация свойств миссии
      Name = "Дипломатическая миссия";
      Duration = _missionDurationDays;
    }

    public override void Execute() {
      // Вывод информации о выполнении миссии
      Console.WriteLine("Переговоры с инопланетной цивилизацией и подписание договора");
    }

    public override string GetReport() {
      // Создание репорта
      string report;

      report = $"{Name}: {_agreementsCount} подписанных торговых соглашений";

      return report;
    }
  }
}