using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    private readonly int diplomaticMissionDurationDays;
    private readonly int diplomaticTradeAgreements;

    public DiplomaticMissionFactory() {
    }

    public DiplomaticMissionFactory(int diplomaticMissionDurationDays, int diplomaticTradeAgreements) {
      this.diplomaticMissionDurationDays = diplomaticMissionDurationDays;
      this.diplomaticTradeAgreements = diplomaticTradeAgreements;
    }

    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}