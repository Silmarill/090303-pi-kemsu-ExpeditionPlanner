using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    public ExplorationMission() {
      _name = "Исследовательская миссия";
      Duration = 30;
    }

    public override void Execute() {
      Console.WriteLine("🧐 Картографирование сектора, сбор научных данных");
    }

    public override string GetReport() {
      return $" 💫 {_name}: открыто несколько новых звёздных систем";
    }
  }
}
