namespace ExpeditionPlanner.Models {
  using System;

  public class CombatMission : Mission {
    private readonly int _destroyedEnemyShips;

    public CombatMission(int duration, int destroyedEnemyShips) {
      this.Name = "Боевая миссия";
      this.Duration = duration;
      _destroyedEnemyShips = destroyedEnemyShips;
    }

    public override void Execute() {
      Console.WriteLine("Патрулирование сектора, уничтожение пиратов");
    }

    public override string GetReport() {
      return $"Боевая миссия: уничтожено {_destroyedEnemyShips} вражеских кораблей";
    }
  }
}