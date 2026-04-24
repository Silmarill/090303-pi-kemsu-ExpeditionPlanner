using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int BaseDuration;
    public int PeoplePerExtraDay;
    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      BaseDuration = 5;
      _peopleCount = peopleCount;
      PeoplePerExtraDay = 10;
      Name = "Спасательная миссия";
      Duration = (BaseDuration + peopleCount) / PeoplePerExtraDay;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}