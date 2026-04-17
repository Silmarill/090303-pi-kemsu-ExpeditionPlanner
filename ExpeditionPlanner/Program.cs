using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;
using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  internal class Program {
    private const int NumberOfRandomMissionsToGenerate = 1;

    static void Main() {
      RandomMissionFactory randomMissionFactory = new RandomMissionFactory();

      Console.WriteLine("=== План миссий на месяц ===\n");

      int currentMissionIndex = 0;
      while (currentMissionIndex++ < NumberOfRandomMissionsToGenerate) {
        Mission currentMission = randomMissionFactory.CreateMission();

        Console.WriteLine($"Миссия: {currentMission.Name} (длительность: {currentMission.Duration} дней)");
        currentMission.Execute();
        Console.WriteLine(currentMission.GetReport());
        Console.WriteLine();
      }
    }
  }
}