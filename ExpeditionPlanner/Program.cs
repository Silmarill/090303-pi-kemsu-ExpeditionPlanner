using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static readonly int _rescueCrewCapacity = 50;

    private static void Main() {
      List<MissionFactory> factories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(_rescueCrewCapacity),
        new RandomMissionFactory()
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      foreach (MissionFactory factory in factories) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метод у всех одинаковый
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}
