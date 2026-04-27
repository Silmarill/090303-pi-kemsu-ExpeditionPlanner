using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    private static void Main() {
      Console.WriteLine("=== Планировщик экспедиций ===\n");
      MissionFactory factory = new RandomMissionFactory();

      Console.WriteLine("Запуск случайной миссии:\n");
      Mission mission = factory.CreateMission();
      Console.WriteLine($"Миссия: {mission.Name}");
      Console.WriteLine($"Длительность: {mission.Duration} дней");
      Console.Write("Действие: ");
      mission.Execute();
      Console.WriteLine($"Отчёт: {mission.GetReport()}");

      Console.WriteLine("\nНажмите любую клавишу для завершения...");
      _ = Console.ReadKey();
    }
  }
}