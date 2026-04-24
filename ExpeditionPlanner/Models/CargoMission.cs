namespace ExpeditionPlanner.Models {
  public class CargoMission : Mission {
    public CargoMission() {
      Name = "Грузовая миссия";
      Duration = 10;
    }

    public override string Execute() {
      return " Доставка ресурсов на орбитальную станцию";
    }

    public override string GetReport() {
      return $" {Name}: доставлено 500 тонн груза";
    }
  }
}
