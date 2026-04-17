using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public RescueMission(int peopleCount) {
      Name = "Спасательская миссия";
      _peopleCount = peopleCount;
      Duration = 5 + _peopleCount / 10;
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакувция {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
