using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private int _defaultDurationMinutes = 30;
    private int _defaultTradeAgreements = 3;
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = _defaultDurationMinutes;
    }

    public override void Execute() {
      Console.WriteLine(" Переговоры с инопланетной цивилизацией");
    }

    public override string GetReport() {
      return $" {Name}: заключено {_defaultTradeAgreements} торговых соглашения";
    }
  }
}
