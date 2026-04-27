using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      // Список фабрик миссий
      List<MissionFactory> factories = new List<MissionFactory>
      {
        new RandomMissionFactory()
      };

      Console.WriteLine("=== План миссии на месяц ===\n");

      foreach (MissionFactory factory in factories) {
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (продолжительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}