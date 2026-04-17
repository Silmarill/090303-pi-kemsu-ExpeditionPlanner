using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public string Name => "Дипломатическая миссия";
    public int Duration => 20;

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return "Дипломатическая миссия: заключено 5 торговых соглашения";
    }
  }
}