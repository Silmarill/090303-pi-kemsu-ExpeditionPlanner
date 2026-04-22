namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private readonly int _dayDuration = 20;
    private readonly int _countTradeAgreements = 3;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = _dayDuration;
    }

    public override string Execute() {
      return "Переговоры с инопланетной цивилизацией, подписание договора";
    }

    public override string GetReport() {
      return $"{Name}: заключено {_countTradeAgreements} торговых соглашения";
    }
  }
}