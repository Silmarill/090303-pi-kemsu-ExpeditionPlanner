using System;

namespace ExpeditionPlanner.Models {
  public class CargoMission : Mission {
    private const int DefaultDurationDays = 10;

    public CargoMission() {
      Name = "Грузовая миссия";
      Duration = DefaultDurationDays;
    }

    public override string Execute() {
      return " Доставка ресурсов на орбитальную станцию";
    }

    public override string GetReport() {
      return $" {Name}: доставлено 500 тонн груза";
    }
  }
}