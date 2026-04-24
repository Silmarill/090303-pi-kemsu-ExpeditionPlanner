using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public abstract class MissionFactory {
    // Тот самыф ФАБРИЧНЫЙ МЕТОД — возвращает абстрактный продукт
    public abstract Mission CreateMission();
  }
}