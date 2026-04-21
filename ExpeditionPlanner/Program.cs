using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main() {
      List<MissionFactory> factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(58)
      };

      RandomMissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== СЛУЧАЙНАЯ МИССИЯ (ЗАДАНИЕ 3) ===\n");
      Mission randomMission = randomFactory.CreateMission();
      Console.WriteLine($"Тип: {randomMission.GetType().Name}");
      Console.WriteLine($"Миссия: {randomMission._name} (длительность: {randomMission.Duration} дней)");
      randomMission.Execute();
      Console.WriteLine(randomMission.GetReport());
      Console.WriteLine();

      Console.WriteLine("=== ВСЕ ТИПЫ МИССИЙ ===\n");

      foreach (MissionFactory factory in factories) {
        Mission mission = factory.CreateMission();
        Console.WriteLine($"Миссия: {mission._name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}