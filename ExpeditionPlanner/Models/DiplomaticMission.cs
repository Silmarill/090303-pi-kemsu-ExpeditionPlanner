using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    int dayDuration = 20;
    int countTradeAgreements = 3;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = dayDuration;
    }

    public override string Execute() {
      return "Переговоры с инопланетной цивилизацией, подписание договора";
    }

    public override string GetReport() {
      return $"{Name}: заключено {countTradeAgreements} торговых соглашения";
    }
  }
}