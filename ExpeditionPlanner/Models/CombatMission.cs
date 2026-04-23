using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    public CombatMission() {
      Name = "Боевая миссия";
      Duration = 15;
    }

    public override void Execute() {
      Console.WriteLine(" Патрулирование, уничтожение пиратов");
    }

    public override string GetReport() {
      return $" {Name}: уничтожено 12 вражеских кораблей";
    }
  }

}