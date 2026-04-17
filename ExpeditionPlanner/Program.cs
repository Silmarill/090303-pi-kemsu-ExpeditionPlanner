using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;
using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      // Объявление фабрик миссий (список)
      List<MissionFactory> factories;

      factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory()
      };

      Console.WriteLine("=== Mission plan for the month ===\n");

      // Выполнение миссий, созданных фабриками
      foreach (MissionFactory factory in factories) {
        // Создание миссии через фабрику
        Mission mission;

        mission = factory.CreateMission();

        // Выполнение миссии и вывод отчета
        Console.WriteLine($"Mission: {mission.Name} (duration: {mission.Duration} days)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}