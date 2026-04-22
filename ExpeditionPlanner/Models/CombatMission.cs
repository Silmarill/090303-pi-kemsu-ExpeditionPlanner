using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    int destroyEnemyShip = 12;

    public CombatMission() {
      Name = "Боевая миссия";
      Duration = 15;
    }

    public override string Execute() {
      return " Патрулирование, уничтожение пиратов";
    }

    public override string GetReport() {
      return $" {Name}: уничтожено {destroyEnemyShip} вражеских кораблей";
    }
  }
}