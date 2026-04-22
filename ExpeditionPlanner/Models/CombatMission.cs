namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    private readonly int _destroyEnemyShip = 12;

    public CombatMission() {
      Name = "Боевая миссия";
      Duration = 15;
    }

    public override string Execute() {
      return " Патрулирование, уничтожение пиратов";
    }

    public override string GetReport() {
      return $" {Name}: уничтожено {_destroyEnemyShip} вражеских кораблей";
    }
  }
}