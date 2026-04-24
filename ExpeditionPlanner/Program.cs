using System;
using System.Collections.Generic;
using System.Text;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main() {
      Console.OutputEncoding = Encoding.UTF8;

      int defaultEvacuationPeopleCount = 100;
      int rescueBasePreparationDays = 5;
      int rescuePeopleEvacuatedPerDay = 10;
      int cargoMissionDurationDays = 10;
      int combatMissionDurationDays = 15;
      int diplomaticMissionDurationDays = 20;
      int explorationMissionDurationDays = 30;
      int cargoDeliveredTons = 500;
      int combatDestroyedEnemyShips = 12;
      int diplomaticTradeAgreements = 3;
      int explorationNewStarSystems = 5;

      List<MissionFactory> factories = new List<MissionFactory>
      {
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
                    explorationNewStarSystems)
            };

      Console.WriteLine("=== План миссий на месяц ===\n");

      for (int missionFactoryIndex = 0; missionFactoryIndex < factories.Count; ++missionFactoryIndex) {
        MissionFactory factory = factories[missionFactoryIndex];
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      Console.ReadKey();
    }
  }
}