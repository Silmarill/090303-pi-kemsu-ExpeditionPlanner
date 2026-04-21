using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;

    public RescueMission(int peopleCount) {
      _name = "Спасательная миссия";
      _peopleCount = peopleCount;
      Duration = 5 + (peopleCount / 10);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {_name}: спасено {_peopleCount} человек";
    }
  }
}
