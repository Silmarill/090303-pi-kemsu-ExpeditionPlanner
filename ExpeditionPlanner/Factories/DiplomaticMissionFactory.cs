using ExpeditionPlanner.Models;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}
