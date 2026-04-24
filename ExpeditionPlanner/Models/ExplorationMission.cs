using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    public ExplorationMission() {
      Name = "Исследовательская миссия";
      Duration = 14;
    }

    public override void Execute() {
      Console.WriteLine("Картографирование сектора, сбор эхо-образцов");
    }

    public override string GetReport() {
      return "Исследовательская миссия: открыто 5 новых систем";
    }
  }
}