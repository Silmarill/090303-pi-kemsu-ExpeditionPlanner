using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    int _peoplecount;

    public RescueMissionFactory(int peoplecount) {
      _peoplecount = peoplecount;
    }
    
    public override Mission CreateMission() {
      return new RescueMission(_peoplecount);
    }
  }
}
