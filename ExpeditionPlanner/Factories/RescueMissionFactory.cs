
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private readonly int _peopleCount;

    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public override Mission CreateMission() {
      RescueMission rescuemission = new RescueMission(_peopleCount);
      // Проверка на правильность подсчитанных дней
      int _peopleCountForOneDay = 10;
      int incorrectCountDaysForMission = 0;

      if (((5 + _peopleCount) % _peopleCountForOneDay) != incorrectCountDaysForMission) {
        ++rescuemission.Duration;
      }

      return rescuemission;
    }
  }
}
