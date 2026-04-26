using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private readonly int _tradeAgreementsCount;

    public DiplomaticMission(int durationDays, int tradeAgreementsCount) {
      Name = "Дипломатическая миссия";
      Duration = durationDays;
      _tradeAgreementsCount = tradeAgreementsCount;
    }

    public override void Execute() {
      Console.WriteLine($" Переговоры: подготовлено к подписанию {_tradeAgreementsCount} торговых соглашений");
    }

    public override string GetReport() {
      return $" {Name}: заключено {_tradeAgreementsCount} торговых соглашений";
    }
  }
}
