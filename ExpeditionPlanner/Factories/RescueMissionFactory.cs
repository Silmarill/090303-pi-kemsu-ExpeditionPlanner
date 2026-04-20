using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  // Фабрика для создания спасательных миссий
  public class RescueMissionFactory : MissionFactory {
    private int _peopleCount;

    // Принимает количество людей, которых нужно спасти, для создания миссии
    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }

    // Создает и возвращает новую спасательную миссию с заданным количеством людей
    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}