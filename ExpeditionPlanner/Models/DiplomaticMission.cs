namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private const int diplomaticMissionDurationDays = 20;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = diplomaticMissionDurationDays;
    }

    public override string Execute() {
      return " Переговоры с инопланетной цивилизацией, подписание договора";
    }

    public override string GetReport() {
      return $" {Name}: заключены торговые соглашения";
    }
  }
}
