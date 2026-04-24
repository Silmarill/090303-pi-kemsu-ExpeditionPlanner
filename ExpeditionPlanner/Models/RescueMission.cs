using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;
    private readonly int _baseDurationDays = 5;
    private readonly int _peopleToDurationDivisor = 10;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = _baseDurationDays + (peopleCount / _peopleToDurationDivisor);
    }

    public override void Execute() {
      // бизнес-логика 
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }

    public string GetExecutionMessage() {
      return $"Спасательная операция: эвакуация {_peopleCount} человек";
    }
  }
}