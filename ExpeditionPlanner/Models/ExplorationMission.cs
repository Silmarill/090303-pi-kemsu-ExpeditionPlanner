using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    private readonly int _newStarSystems;

    public ExplorationMission(int duration, int newStarSystems) {
      Name = "Исследовательская миссия";
      Duration = duration;
      _newStarSystems = newStarSystems;
    }

    public override void Execute() {
      Console.WriteLine("Картографирование сектора, сбор образцов");
    }

    public override string GetReport() {
      return $"Исследовательская миссия: открыто {_newStarSystems} новых систем";
    }
  }
}