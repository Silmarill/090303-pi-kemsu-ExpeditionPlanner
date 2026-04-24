using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private int _tradeAgreements;

    public DiplomaticMission(int duration, int tradeAgreements) {
      Name = "Дипломатическая миссия";
      Duration = duration;
      _tradeAgreements = tradeAgreements;
    }

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return $"Дипломатическая миссия: заключено {_tradeAgreements} торговых соглашения";
    }
  }
}