using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public RescueMission(int peopleCount) {
      Name = "Спасательская миссия";
      _peopleCount = peopleCount;
      Duration = 5 + _peopleCount / 10;
    }

    public override void Execute() {
      Console.WriteLine(" Спасательная операция");
    }

    public override string GetReport() {
      return $" {Name}: открыто 5 новых звёздных систем";
    }
  }
}
