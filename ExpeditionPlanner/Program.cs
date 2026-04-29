using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      MissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== План миссий на месяц ===\n");

      int missionCount = 5;

      for (int missionIndex = 0; missionIndex < missionCount; ++missionIndex) {
        Mission mission = randomFactory.CreateMission();
        string executionResult = mission.Execute();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        Console.WriteLine(executionResult);
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}
