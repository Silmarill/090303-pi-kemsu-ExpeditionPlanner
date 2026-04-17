
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
      public class DiplomaticMissionFactory : MissionFactory {
      public override Mission CreateMission() {
        return new DiplomaticMission();
      }
    }
  }