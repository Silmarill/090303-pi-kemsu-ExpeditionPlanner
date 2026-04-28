using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int BaseDuration = 5;
    private const int PeoplePerDurationUnit = 10;

    private int _peopleCount;
    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public new string Name {
      get { return "Спасательная миссия"; }
    }

    public new int Duration {
      get { return BaseDuration + _peopleCount / PeoplePerDurationUnit; }
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}