using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    private int _duration;
    private int _tradeAgreements;

    public DiplomaticMissionFactory(int duration, int tradeAgreements) {
      _duration = duration;
      _tradeAgreements = tradeAgreements;
    }

    public override Mission CreateMission() {
      return new DiplomaticMission(_duration, _tradeAgreements);
    }
  }
}