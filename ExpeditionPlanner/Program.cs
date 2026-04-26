using System;
using System.Collections.Generic;
using System.Text;
using ExpeditionPlanner.Factories;

// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      Console.OutputEncoding = Encoding.UTF8;

      int defaultEvacuationPeopleCount;
      defaultEvacuationPeopleCount = 100;

      int rescueBasePreparationDays;
      rescueBasePreparationDays = 5;

      int rescuePeopleEvacuatedPerDay;
      rescuePeopleEvacuatedPerDay = 10;

      int cargoMissionDurationDays;
      cargoMissionDurationDays = 10;

      int combatMissionDurationDays;
      combatMissionDurationDays = 15;

      int diplomaticMissionDurationDays;
      diplomaticMissionDurationDays = 20;

      int explorationMissionDurationDays;
      explorationMissionDurationDays = 30;

      int cargoDeliveredTons;
      cargoDeliveredTons = 500;

      int combatDestroyedEnemyShips;
      combatDestroyedEnemyShips = 12;

      int diplomaticTradeAgreements;
      diplomaticTradeAgreements = 3;

      int explorationNewStarSystems;
      explorationNewStarSystems = 5;

      List<MissionFactory> factories;
      factories = new List<MissionFactory> {
        new ExplorationMissionFactory(explorationMissionDurationDays, explorationNewStarSystems),
        new CombatMissionFactory(combatMissionDurationDays, combatDestroyedEnemyShips),
        new CargoMissionFactory(cargoMissionDurationDays, cargoDeliveredTons),
        new DiplomaticMissionFactory(diplomaticMissionDurationDays, diplomaticTradeAgreements),
        new RescueMissionFactory(defaultEvacuationPeopleCount, rescueBasePreparationDays, rescuePeopleEvacuatedPerDay),
        new RandomMissionFactory(
          defaultEvacuationPeopleCount,
          rescueBasePreparationDays,
          rescuePeopleEvacuatedPerDay,
          cargoMissionDurationDays,
          combatMissionDurationDays,
          diplomaticMissionDurationDays,
          explorationMissionDurationDays,
          cargoDeliveredTons,
          combatDestroyedEnemyShips,
          diplomaticTradeAgreements,
          explorationNewStarSystems),
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      for (int missionFactoryIndex = 0; missionFactoryIndex < factories.Count; ++missionFactoryIndex) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа — метод у всех одинаковый
        MissionFactory factory;
        factory = factories[missionFactoryIndex];

        Mission mission;
        mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      // Легко добавить новую миссию, не меняя существующий код!
      // MissionFactory newFactory = new DiplomaticMissionFactory(...); // придумаем позже
      // Mission diplomaticMission = newFactory.CreateMission();
      // diplomaticMission.Execute();
    }
  }
}
