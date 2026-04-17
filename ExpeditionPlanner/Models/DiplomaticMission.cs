using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private int missionDurationDays = 20;
    private int agreementsCount = 3;

    public DiplomaticMission() {
      // инициализация свойств миссии
      Name = "Diplomatic mission";
      Duration = missionDurationDays;
    }

    public override void Execute() {
      // Вывод информации о выполнении миссии
      Console.WriteLine("Negotiations with alien civilization and treaty signing");
    }

    public override string GetReport() {
      // Создание репорта
      string report;

      report = $"{Name}: {agreementsCount} trade agreements signed";

      return report;
    }
  }
}