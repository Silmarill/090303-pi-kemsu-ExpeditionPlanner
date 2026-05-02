using System;

namespace ExpeditionPlanner.Models {
  public class CargoMission : Mission {
    private readonly int _deliveredTons;

    public CargoMission(int duration, int deliveredTons) {
      Name = "Грузовая миссия";
      Duration = duration;
      _deliveredTons = deliveredTons;
    }

    public override void Execute() {
      Console.WriteLine("Доставка ресурсов на орбитальную станцию");
    }

    public override string GetReport() {
      return $"📄 Грузовая миссия: доставлено {_deliveredTons} тонн груза";
    }
  }
}