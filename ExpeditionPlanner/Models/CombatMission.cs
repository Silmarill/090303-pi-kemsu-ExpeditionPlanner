using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    public CombatMission() {
      Name = "Боевая миссия";
      Duration = 10;
    }

    public override void Execute() {
      Console.WriteLine("Патрулирование сектора, уничтожение пиратов");
    }

    public override string GetReport() {
      return "Боевая миссия: уничтожено 12 вражеских кораблей";
    }
  }
}