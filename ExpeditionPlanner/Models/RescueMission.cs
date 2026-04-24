using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;

    public RescueMission(int peopleCount, int basePreparationDays, int peoplePerDay) {
      Name = "Спасательная миссия";
      Duration = basePreparationDays + (peopleCount / peoplePerDay);
      _peopleCount = peopleCount;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}