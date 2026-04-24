namespace ExpeditionPlanner.Models {
  using System;

  public class ExplorationMission : Mission {
    private readonly int _newStarSystems;

    public ExplorationMission(int duration, int newStarSystems) {
      this.Name = "Исследовательская миссия";
      this.Duration = duration;
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