using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public abstract class MissionFactory {
    // Тот самый ФАБРИЧНЫЙ МЕТОД — возвращает абстрактный продукт
    public abstract Mission CreateMission();
  }
}