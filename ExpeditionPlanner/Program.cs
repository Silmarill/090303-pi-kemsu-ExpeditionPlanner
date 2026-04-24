using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main() {
      List<MissionFactory> planFactories = new List<MissionFactory> {
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(50)
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      foreach (MissionFactory factory in planFactories) {
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        Console.WriteLine(mission.Execute());
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      Console.WriteLine("=== Случайная миссия ===\n");
      MissionFactory randomFactory = new RandomMissionFactory();
      Mission randomMission = randomFactory.CreateMission();

      Console.WriteLine($"Миссия: {randomMission.Name} (длительность: {randomMission.Duration} дней)");
      Console.WriteLine(randomMission.Execute());
      Console.WriteLine(randomMission.GetReport());
      Console.WriteLine();

      // Легко добавить новую миссию, не меняя существующий код!
      // MissionFactory newFactory = new DiplomaticMissionFactory(); // придумаем позже
      // Mission diplomaticMission = newFactory.CreateMission();
      // diplomaticMission.Execute();
    }
  }
}