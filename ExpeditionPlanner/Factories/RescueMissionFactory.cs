using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private readonly int _peopleCount;
    private readonly int _preparationDaysBase;
    private readonly int _peopleEvacuatedPerDay;

    public RescueMissionFactory(int peopleCount, int preparationDaysBase, int peopleEvacuatedPerDay) {
      _peopleCount = peopleCount;
      _preparationDaysBase = preparationDaysBase;
      _peopleEvacuatedPerDay = peopleEvacuatedPerDay;
    }

    public override Mission CreateMission() {
      return new RescueMission(
        _peopleCount,
        _preparationDaysBase,
        _peopleEvacuatedPerDay);
    }
  }
}
