namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private int _tradeAgreementsCount;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = 2;
      _tradeAgreementsCount = 0;
    }

    public override void Execute() {
      _tradeAgreementsCount = 3;
    }

    public override string GetReport() {
      return $"{Name}: заключено {_tradeAgreementsCount} торговых соглашения";
    }
  }
}