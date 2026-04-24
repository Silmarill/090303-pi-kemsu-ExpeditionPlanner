namespace ExpeditionPlanner.Models {
  using System;

  public class RescueMission : Mission {
    private readonly int _peopleCount;

    public RescueMission(int peopleCount, int basePreparationDays, int peoplePerDay) {
      this._peopleCount = peopleCount;
      this.Name = "Спасательная миссия";
      this.Duration = basePreparationDays + (peopleCount / peoplePerDay);
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}