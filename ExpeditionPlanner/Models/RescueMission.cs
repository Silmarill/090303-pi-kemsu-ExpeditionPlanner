using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int BaseDurationDays = 5;
    public int peoplePerExtraDay = 10;
    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = BaseDurationDays + (peopleCount / peoplePerExtraDay);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
