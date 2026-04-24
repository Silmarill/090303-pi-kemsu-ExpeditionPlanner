using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    private readonly int _defaultDurationDays = 30;
    public ExplorationMission() {
      Name = "Исследовательская миссия";
      Duration = _defaultDurationDays;
    }

    public override void Execute() {
      Console.WriteLine(" Картографирование сектора, сбор научных данных");
    }

    public override string GetReport() {
      return $" {Name}: открыто 5 новых звёздных систем";
    }
  }
}
