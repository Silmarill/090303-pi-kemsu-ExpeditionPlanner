using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("=== Планировщик экспедиций ===\n");

      MissionFactory factory = new RandomMissionFactory();

      for (int i = 1; i <= 5; ++i) {
        Console.WriteLine($"--- Миссия {i} ---");
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Название: {mission.Name}");
        Console.WriteLine($"Длительность: {mission.Duration} дней");
        mission.Execute();
        Console.WriteLine($"Отчёт: {mission.GetReport()}");
        Console.WriteLine();
      }

      Console.WriteLine("Нажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}