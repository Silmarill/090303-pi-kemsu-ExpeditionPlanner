using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine(" Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return $" {Name}: заключено 3 торговых соглашения";
    }
  }
}