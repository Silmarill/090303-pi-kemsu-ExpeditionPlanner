using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();
    private int _defaultPeopleCount;
    public RandomMissionFactory() {
      _defaultPeopleCount = 100;
      _factories = new List<MissionFactory> {
        new RescueMissionFactory(_defaultPeopleCount),
        new CargoMissionFactory(),
        new CombatMissionFactory(),
        new DiplomaticMissionFactory(),
        new ExplorationMissionFactory(),
      };
    }
    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}
