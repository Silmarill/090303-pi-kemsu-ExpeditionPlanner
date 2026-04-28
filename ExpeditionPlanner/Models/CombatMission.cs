using System;

namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    public CombatMission() {
      _name = "Боевая миссия";
      Duration = 15;
    }

    public override void Execute() {
      Console.WriteLine(" Патрулирование, уничтожение пиратов");
    }

    public override string GetReport() {
      return $" {_name}: вражеские корабли уничтожены";
    }
  }
}
