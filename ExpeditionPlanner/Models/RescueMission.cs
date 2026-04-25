using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int BaseDuration = 5;
    private const int PeoplePerDurationUnit = 10;

    private int _peopleCount;
    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public string Name => "Спасательная миссия";
    public int Duration => BaseDuration + _peopleCount / PeoplePerDurationUnit;

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}