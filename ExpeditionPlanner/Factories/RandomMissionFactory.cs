using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();
    int randomIndex;
    public RandomMissionFactory() {
      _factories = new List<MissionFactory>();

      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new RescueMissionFactory(50));
      _factories.Add(new DiplomaticMissionFactory());
    }

    public override Mission CreateMission() {
        randomIndex = _random.Next(_factories.Count);
        MissionFactory randomFactory = _factories[randomIndex];
        return randomFactory.CreateMission();
    }
  }
}
