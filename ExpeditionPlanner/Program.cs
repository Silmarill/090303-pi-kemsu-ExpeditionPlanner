using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    internal static void Main() {
      // Создаём фабрики разных типов -> одну случайную фабрику вместо списка
      MissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== Случайные миссии ===\n");

      Mission mission = randomFactory.CreateMission();

      Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
      mission.Execute();
      Console.WriteLine(mission.GetReport());
      Console.WriteLine();
    }
  }
}