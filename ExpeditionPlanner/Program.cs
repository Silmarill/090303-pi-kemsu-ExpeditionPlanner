using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      int missionCount = 5;
      int startNumber = 1;
      MissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== Случайные миссии экспедиции ===\n");

      for (int missionNumber = startNumber; missionNumber <= missionCount; ++missionNumber) {
        Console.WriteLine($"--- Миссия #{missionNumber} ---");
        Mission mission = randomFactory.CreateMission();
        Console.WriteLine($"Название: {mission.Name}");
        Console.WriteLine($"Длительность: {mission.Duration} дней");
        mission.Execute();
        string actionMessage = mission.GetExecutionMessage();
        if (!string.IsNullOrEmpty(actionMessage)) {
          Console.WriteLine(actionMessage);
        }

        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}