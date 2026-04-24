using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private readonly int _durationDays = 20;
    private readonly int _tradeAgreementsCount = 3;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = _durationDays;
    }

    public override void Execute() {
      // бизнес-логика
    }

    public override string GetReport() {
      return $"Дипломатическая миссия: заключено {_tradeAgreementsCount} торговых соглашения";
    }

    public string GetExecutionMessage() {
      return "Переговоры с инопланетной цивилизацией, подписание договора";
    }
  }
}