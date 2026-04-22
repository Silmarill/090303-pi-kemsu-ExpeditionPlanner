using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories
{
  public class DiplomaticMissionFactory : MissionFactory
  {
    private int _durationDays;
    private int _tradeAgreementsCount;

    public DiplomaticMissionFactory(int durationDays, int tradeAgreementsCount)
    {
      _durationDays = durationDays;
      _tradeAgreementsCount = tradeAgreementsCount;
    }

    public override Mission CreateMission()
    {
      return new DiplomaticMission(_durationDays, _tradeAgreementsCount);
    }
  }
}
