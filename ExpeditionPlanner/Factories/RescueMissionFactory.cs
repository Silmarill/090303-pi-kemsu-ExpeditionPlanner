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
      int peopleCountForOneDay = 10,
        halfPeopleCountForOneDay = 5;
      int incorrectCountDaysForMission = 0;

      if (((halfPeopleCountForOneDay + _peopleCount) % peopleCountForOneDay) != incorrectCountDaysForMission) {
        ++rescuemission.Duration;
      }

      return rescuemission;
    }
  }
}
