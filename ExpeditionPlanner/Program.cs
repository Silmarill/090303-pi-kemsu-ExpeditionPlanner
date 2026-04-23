using System;
using ExpeditionPlanner.Models;
using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      RandomMissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== План миссий на месяц ===\n");

      for (int missionIndex = 0; missionIndex < 5; ++missionIndex) {
        Mission currentMission = randomFactory.CreateMission();

        Console.WriteLine($"Миссия: {currentMission.Name} (длительность: {currentMission.Duration} дней)");
        currentMission.Execute();
        Console.WriteLine(currentMission.GetReport());
        Console.WriteLine();
      }
    }
  }
}