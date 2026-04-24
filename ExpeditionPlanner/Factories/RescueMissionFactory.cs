namespace ExpeditionPlanner.Factories {
  using ExpeditionPlanner.Models;

  public class RescueMissionFactory : MissionFactory {
    private readonly int _peopleCount;
    private readonly int _basePreparationDays;
    private readonly int _peoplePerDay;

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