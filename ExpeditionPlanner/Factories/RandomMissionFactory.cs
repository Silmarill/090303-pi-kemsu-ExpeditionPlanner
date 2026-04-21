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

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>();
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new RescueMissionFactory(50));
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}
