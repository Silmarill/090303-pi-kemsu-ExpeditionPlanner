namespace ExpeditionPlanner.Models {
  using System;

  public class DiplomaticMission : Mission {
    private readonly int _tradeAgreements;

    public DiplomaticMission(int duration, int tradeAgreements) {
      this.Name = "Дипломатическая миссия";
      this.Duration = duration;
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