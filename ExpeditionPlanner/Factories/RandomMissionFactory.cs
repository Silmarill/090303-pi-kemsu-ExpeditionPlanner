using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {

    private static Random random = new Random();

    private static int _peopleCount = random.Next(1, 1000);

    private List<Mission> missions = new List<Mission>
    {
            new CargoMission(),
            new CombatMission(),
            new DiplomaticMission(),
            new DiplomaticMission(),
            new RescueMission(_peopleCount)
    };

    public override Mission CreateMission() {
      Mission selectedMission = missions[random.Next(missions.Count)];

      return selectedMission;
    }
  }
}
