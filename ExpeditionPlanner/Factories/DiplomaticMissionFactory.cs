namespace ExpeditionPlanner.Factories {
  using ExpeditionPlanner.Models;

  public class DiplomaticMissionFactory : MissionFactory {
    private readonly int _duration;
    private readonly int _tradeAgreements;

    public DiplomaticMissionFactory(int duration, int tradeAgreements) {
      _duration = duration;
      _tradeAgreements = tradeAgreements;
    }

    public override Mission CreateMission() {
      return new DiplomaticMission(_duration, _tradeAgreements);
    }
  }
}