using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main(string[] args) {
      Console.WriteLine("=== Планировщик экспедиций ===\n");

      MissionFactory factory = new RandomMissionFactory();

      int quantityMission;
      quantityMission = 5;
      int counterI;
      counterI = 1;
      int num;
      num = 1;

      for (num = counterI; num <= quantityMission; ++num) {
        Console.WriteLine($"--- Миссия {num} ---");
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Название: {mission.Name}");
        Console.WriteLine($"Длительность: {mission.Duration} дней");
        mission.Execute();
        Console.WriteLine($"Отчёт: {mission.GetReport()}");
        Console.WriteLine();
      }

      Console.WriteLine("Нажмите любую клавишу для выхода...");
    }
  }
}