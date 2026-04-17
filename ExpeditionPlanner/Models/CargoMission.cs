using System;

namespace ExpeditionPlanner.Models {
  public class CargoMission : Mission {
    public CargoMission() {
      Name = "Грузовая миссия";
      Duration = 7;
    }

    public override void Execute() {
      Console.WriteLine("Доставка ресурсов на колонию");
    }

    public override string GetReport() {
      return "Грузовая миссия: доставлено 500 тонн ресурсов";
    }
  }
}