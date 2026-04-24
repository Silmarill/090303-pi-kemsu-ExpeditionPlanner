using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  // Фабрика, которая создает случайные миссии, используя другие фабрики для генерации различных типов миссий
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();
    private readonly int _countOfPeopleForRescueMission = 50;

    // Конструктор, который инициализирует список фабрик для создания различных типов миссий
    public RandomMissionFactory() {
      _factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(_countOfPeopleForRescueMission)
      };
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}