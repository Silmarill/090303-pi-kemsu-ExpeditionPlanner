namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public abstract class MissionFactory {
    
    //Тот самыф ФАБРИЧНЫЙ МЕТОД — возвращает абстрактный продукт
    public abstract Mission CreateMission();
  }
}
