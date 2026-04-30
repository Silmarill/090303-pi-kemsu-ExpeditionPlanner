using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.WriteLine("=== План миссий на месяц ===\n");

      List<MissionFactory> factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(5),
        new CombatMissionFactory(12),
        new CargoMissionFactory(500),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(100)
      };

      foreach (MissionFactory factory in factories) {
        Mission mission = factory.CreateMission();
        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}