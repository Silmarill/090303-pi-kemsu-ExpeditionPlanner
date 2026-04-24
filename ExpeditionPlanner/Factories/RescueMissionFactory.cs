using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private int _peopleCount;
    private int _basePreparationDays;
    private int _peoplePerDay;

    public RescueMissionFactory(int peopleCount, int basePreparationDays, int peoplePerDay) {
      _peopleCount = peopleCount;
      _basePreparationDays = basePreparationDays;
      _peoplePerDay = peoplePerDay;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount, _basePreparationDays, _peoplePerDay);
    }
  }
}