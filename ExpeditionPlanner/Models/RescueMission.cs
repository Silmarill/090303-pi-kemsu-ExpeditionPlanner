using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public int baseDurationDays = 5;
    public int peoplePerExtraDay = 10;
    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = baseDurationDays + (peopleCount / peoplePerExtraDay);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
