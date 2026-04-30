using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private readonly int _peopleCount;
    private readonly int rescuePeopleEvacuatedPerDay;

    public RescueMissionFactory(int peopleCount, int rescueBasePreparationDays) {
      _peopleCount = peopleCount;
    }

    public RescueMissionFactory(int peopleCount, int rescueBasePreparationDays, int rescuePeopleEvacuatedPerDay) : this(peopleCount, rescueBasePreparationDays) {
      this.rescuePeopleEvacuatedPerDay = rescuePeopleEvacuatedPerDay;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}