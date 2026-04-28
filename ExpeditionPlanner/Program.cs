using System;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    public static void Main() {
      RandomMissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== План миссий на месяц ===\n");

      for (int index = 0; index < 5; ++index) {
        Mission mission = randomFactory.CreateMission();

        Console.WriteLine("Миссия: " + mission.Name + " (длительность: " + mission.Duration + " дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}
