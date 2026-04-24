using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public int BaseDuration;
    public int PeoplePerExtraDay;

    public RescueMission(int peopleCount) {
      BaseDuration = 5;
      PeoplePerExtraDay = 10;
      peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = BaseDuration + peopleCount / PeoplePerExtraDay;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}