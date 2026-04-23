using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    private const int DefaultDurationDays = 30;

    public ExplorationMission() {
      Name = "Исследовательская миссия";
      Duration = DefaultDurationDays;
    }

    public override string Execute() {
      return " Картографирование сектора, сбор научных данных";
    }

    public override string GetReport() {
      return $" {Name}: открыто 5 новых звёздных систем ";
    }
  }
}
