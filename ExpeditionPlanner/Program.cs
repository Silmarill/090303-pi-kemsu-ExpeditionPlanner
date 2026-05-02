using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    private const int NumberOfRandomMissions = 5;

    public static void Main() {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.WriteLine("=== План миссий на месяц ===\n");

      MissionFactory factory = new RandomMissionFactory();

      for (int missionCount = 0; missionCount < NumberOfRandomMissions; ++missionCount) {
        Mission mission = factory.CreateMission();
        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      _ = Console.ReadKey();
    }
  }
}