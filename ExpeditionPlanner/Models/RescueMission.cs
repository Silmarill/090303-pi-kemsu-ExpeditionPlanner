using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int BaseRescueDuration = 5;        
    private const int PeoplePerExtraDay = 10;        
    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = BaseRescueDuration + peopleCount / PeoplePerExtraDay;
    }

    public override void Execute() {
      Console.WriteLine($" 🚀 Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"📄 Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}