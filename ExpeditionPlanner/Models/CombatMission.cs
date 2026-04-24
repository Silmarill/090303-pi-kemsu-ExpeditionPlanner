using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    private readonly int _enemyShipsDestroyed;

    public CombatMission(int durationDays, int enemyShipsDestroyed) {
      Name = "Боевая миссия";
      Duration = durationDays;
      _enemyShipsDestroyed = enemyShipsDestroyed;
    }

    public override void Execute() {
      Console.WriteLine($" Патрулирование, уничтожено {_enemyShipsDestroyed} вражеских кораблей");
    }

    public override string GetReport() {
      return $" {Name}: уничтожено {_enemyShipsDestroyed} вражеских кораблей";
    }
  }
}
