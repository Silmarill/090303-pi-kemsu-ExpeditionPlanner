using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int BaseDuration;
    public int PeopleDivider;

    private int _peopleCount;

    public RescueMission(int peopleCount) {
      BaseDuration = 5;
      PeopleDivider = 10;

      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = BaseDuration + peopleCount / PeopleDivider;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}