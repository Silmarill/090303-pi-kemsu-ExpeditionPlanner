using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    public RescueMissionFactory() { }
    
    public override Mission CreateMission() {
      return new RescueMission();
    }
  }
}
