using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int _peopleCount;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = 5 + peopleCount / 10;
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
