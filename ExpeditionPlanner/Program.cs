using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("=== ПЛАНИРОВЩИК ЭКСПЕДИЦИЙ ===\n");

      var factories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(),
                new CombatMissionFactory(),
                new CargoMissionFactory(),
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(50)
            };

      foreach (var factory in factories) {
        Mission mission = factory.CreateMission();
        Console.WriteLine($"Миссия: {mission.Name}");
        Console.WriteLine($"Длительность: {mission.Duration} дней");
        mission.Execute();
        Console.WriteLine($"Отчёт: {mission.GetReport()}");
        Console.WriteLine();
      }

      Console.ReadKey();
    }
  }
}