using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      // Создание объекта
      Mission mission;
      mission = new DiplomaticMission();

      return mission;
    }
  }
}