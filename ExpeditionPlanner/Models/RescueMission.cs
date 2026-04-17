using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const string MissionName = "Спасательная миссия";
    private const int BaseDurationDays = 5;
    private const int PeoplePerAdditionalDay = 10;

    private int _evacuationPeopleCount;

    public RescueMission(int peopleCount) {
      _evacuationPeopleCount = peopleCount;
      Name = MissionName;
      Duration = BaseDurationDays + (peopleCount / PeoplePerAdditionalDay);
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_evacuationPeopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_evacuationPeopleCount} человек";
    }
  }
}