using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public DiplomaticMission() {
      _name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine("Жеские переговоры с иноприщеленцами");
    }

    public override string GetReport() {
      return $" {_name}: успешно проваленна";
    }
  }
}