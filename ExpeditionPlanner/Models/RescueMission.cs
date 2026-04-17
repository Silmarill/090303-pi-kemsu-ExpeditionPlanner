using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public RescueMission(int peopleCount) {
      Name = "Спасательская миссия";
      _peopleCount = peopleCount;

      int basePeopleCount;
      int peoplePerDay;

      basePeopleCount = 5;
      peoplePerDay = 10;

      Duration = basePeopleCount + _peopleCount / peoplePerDay;
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакувция {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
