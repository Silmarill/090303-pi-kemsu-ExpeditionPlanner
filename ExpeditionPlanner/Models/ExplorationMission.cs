namespace ExpeditionPlanner.Models {
  public class ExplorationMission : Mission {
    public ExplorationMission() {
      Name = "Исследовательская миссия";
      Duration = 30;
    }

    public override string Execute() {
      return " Картографирование сектора, сбор научных данных";
    }

    public override string GetReport() {
      return $" {Name}: открыто 5 новых звёздных систем";
    }
  }
}
