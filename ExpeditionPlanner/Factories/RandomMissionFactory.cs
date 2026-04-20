using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  // Фабрика, которая создает случайные миссии, используя другие фабрики для генерации различных типов миссий
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();

    // Конструктор, который инициализирует список фабрик для создания различных типов миссий
    public RandomMissionFactory() {
      _factories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(),
                new CombatMissionFactory(),
                new CargoMissionFactory(),
                new DiplomaticMissionFactory(),

                // Используется фабрика из Задания 2
                new RescueMissionFactory(50)
            };
    }

    // Метод, который создает случайную миссию, выбирая случайную фабрику из списка и вызывая ее метод CreateMission
    public override Mission CreateMission() {
      // Выбирается случайная фабрика
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}