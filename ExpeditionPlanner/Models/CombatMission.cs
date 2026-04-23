using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    private const int DefaultDurationDays = 15;

    public CombatMission() {
      Name = "Боевая миссия";
      Duration = DefaultDurationDays;
    }

    public override string Execute() {
      return " Патрулирование, уничтожение пиратов";
    }

    public override string GetReport() {
      return $" {Name}: уничтожено 12 вражеских кораблей";
    }
  }
}