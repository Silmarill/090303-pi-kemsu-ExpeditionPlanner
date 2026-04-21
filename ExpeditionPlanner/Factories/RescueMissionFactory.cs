using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    int _peopleCount;

    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}
