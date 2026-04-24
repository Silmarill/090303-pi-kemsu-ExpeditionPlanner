using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private const int NumberOfRandomMissionsToGenerate = 1;
    private const int RescuePeopleCount = 50;

    private static void Main() {
      RandomMissionFactory randomMissionFactory = new RandomMissionFactory(RescuePeopleCount);

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