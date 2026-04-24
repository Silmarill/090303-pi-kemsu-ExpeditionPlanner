using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {

    private const int BaseDuration = 5;
    private const int PeoplePerDurationStep = 10;

    private int _peopleCount;
    public RescueMission(int peopleCount) {

      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = BaseDuration + (peopleCount / PeoplePerDurationStep);
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"{Name}: спасено {_peopleCount}";
    }
  }
}
