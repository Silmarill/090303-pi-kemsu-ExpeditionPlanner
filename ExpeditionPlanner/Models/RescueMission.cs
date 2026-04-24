using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;
    private readonly int _baseDurationDays = 5;
    private readonly int _peoplePerAdditionalDay;

    public RescueMission(int peopleCount) {
      _name = "Спасательная миссия";
      _peopleCount = peopleCount;
      Duration = _baseDurationDays + (peopleCount / _peoplePerAdditionalDay);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {_name}: спасено {_peopleCount} человек";
    }
  }
}
