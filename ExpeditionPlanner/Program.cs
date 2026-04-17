using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;
using System;

namespace ExpeditionPlanner {
  class Program {
    static void Main(string[] args) {
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
      Console.ReadKey();
    }
  }
}