using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;
    private readonly int _baseDurationMinutes = 5;
    private readonly int _peolplePerExtraMinute = 10;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = _baseDurationMinutes + (peopleCount / _peolplePerExtraMinute);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
