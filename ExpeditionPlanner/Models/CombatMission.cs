namespace ExpeditionPlanner.Models {
  public class CombatMission : Mission {
    public CombatMission() {
      Name = "Боевая миссия";
      Duration = 15;
    }

    public override string Execute() {
      return " Патрулирование, уничтожение пиратов";
    }

    public override string GetReport() {
      return $" {Name}: уничтожено 12 вражеских кораблей";
    }
  }
}
