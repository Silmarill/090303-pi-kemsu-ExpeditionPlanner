using System;

namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    private readonly int _newStarSystemsDiscovered;

    public ExplorationMission(int durationDays, int newStarSystemsDiscovered) {
      Name = "Исследовательская миссия";
      Duration = durationDays;
      _newStarSystemsDiscovered = newStarSystemsDiscovered;
    }

    public override void Execute() {
      Console.WriteLine($" Картографирование: зафиксировано {_newStarSystemsDiscovered} новых звёздных систем");
    }

    public override string GetReport() {
      return $" {Name}: открыто {_newStarSystemsDiscovered} новых звёздных систем";
    }
  }
}
