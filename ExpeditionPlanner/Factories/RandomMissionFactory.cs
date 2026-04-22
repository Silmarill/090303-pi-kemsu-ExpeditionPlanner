using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private static readonly int _peopleCount = 42;

    private readonly Random _random = new();

    private readonly List<MissionFactory> _factories = [
      new CargoMissionFactory(),
      new CombatMissionFactory(),
      new DiplomaticMissionFactory(),
      new ExplorationMissionFactory(),
      new RescueMissionFactory(_peopleCount)
    ];

    public override Mission CreateMission() {
      int randomIndex = _random.Next(0, _factories.Count);
      MissionFactory selectedFactory = _factories[randomIndex];

      return selectedFactory.CreateMission();
    }
  }
}