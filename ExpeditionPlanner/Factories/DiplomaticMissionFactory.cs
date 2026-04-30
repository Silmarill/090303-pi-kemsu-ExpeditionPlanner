using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    private int diplomaticMissionDurationDays;
    private int diplomaticTradeAgreements;

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