using System;

namespace ExpeditionPlanner.Models {
  public class CargoMission : Mission {
    private readonly int _cargoTonsDelivered;

    public CargoMission(int durationDays, int cargoTonsDelivered) {
      Name = "Грузовая миссия";
      Duration = durationDays;
      _cargoTonsDelivered = cargoTonsDelivered;
    }

    public override void Execute() {
      Console.WriteLine($" Доставка {_cargoTonsDelivered} тонн ресурсов на орбитальную станцию");
    }

    public override string GetReport() {
      return $" {Name}: доставлено {_cargoTonsDelivered} тонн груза";
    }
  }
}
