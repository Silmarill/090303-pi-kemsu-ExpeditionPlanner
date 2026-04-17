using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      int MissionCount;
      int StartNumber;
      MissionFactory randomFactory;

      MissionCount = 5;
      StartNumber = 1;
      randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== Случайные миссии экспедиции ===\n");

      for (int missionNumber = StartNumber; missionNumber <= MissionCount; ++missionNumber) {
        Console.WriteLine($"--- Миссия #{missionNumber} ---");
        Mission mission = randomFactory.CreateMission();
        Console.WriteLine($"Название: {mission.Name}");
        Console.WriteLine($"Длительность: {mission.Duration} дней");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}