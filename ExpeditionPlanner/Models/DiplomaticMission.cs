using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private readonly int _numberOfTradeAgreementsConcluded = 3;

    public DiplomaticMission() {
      _name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine(" Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return $" {_name}: заключено {_numberOfTradeAgreementsConcluded} торговых соглашения";
    }
  }
}
