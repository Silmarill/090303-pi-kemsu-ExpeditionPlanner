using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int BaseDurationDays = 5;
    public int PeoplePerAdditionalDay = 10;
    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      _name = "Спасательная миссия";
      _peopleCount = peopleCount;
      Duration = BaseDurationDays + (peopleCount / PeoplePerAdditionalDay);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {_name}: спасено {_peopleCount} человек";
    }
  }
}
