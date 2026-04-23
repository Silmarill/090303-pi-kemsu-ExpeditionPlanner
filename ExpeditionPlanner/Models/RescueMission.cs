using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    private int _baseDurationMinutes = 5;
    private int _peolplePerExtraMinute = 10;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = _baseDurationMinutes + peopleCount / _peolplePerExtraMinute;
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
