using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;
    private readonly int _peopleCountForOneDay = 10;
    private readonly int halfPeopleCountForOneDay = 5;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      _name = "Спасательная миссия";
      Duration = (halfPeopleCountForOneDay + peopleCount) / _peopleCountForOneDay;
    }

    public override void Execute() {
      Console.WriteLine($"🚀 Спасательная операция: эвакуация {_peopleCount}");
    }

    public override string GetReport() {
      return $"📃 Спасательная операция: спасено {_peopleCount}";
    }
  }
}
