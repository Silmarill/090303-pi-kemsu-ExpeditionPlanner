using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main(string[] args) {
      int randommissionsCount = 4;
      int rescuemissionpeopleCount = 100;
      int indexoffsetforDisplay = 1;

      RandomMissionFactory randomMissionFactory;
      randomMissionFactory = new RandomMissionFactory();
      Mission currentMission = null;

      Console.WriteLine("=== Случайные миссии (Задание 3) ===");
      for (int missionIndex = 0; missionIndex < randommissionsCount; ++missionIndex) {
        currentMission = randomMissionFactory.CreateMission();
        Console.WriteLine($"[{missionIndex + indexoffsetforDisplay}] {currentMission.Name} ({currentMission.Duration} дн.)");
        currentMission.Execute();
        Console.WriteLine(currentMission.GetReport());
        Console.WriteLine();
      }

      Console.WriteLine("=== Конкретные фабрики ===");
      List<MissionFactory> concreteFactories = new List<MissionFactory>
      {
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(rescuemissionpeopleCount)
            };

      foreach (MissionFactory currentFactory in concreteFactories) {
        currentMission = currentFactory.CreateMission();
        Console.WriteLine($"Миссия: {currentMission.Name}, длительность: {currentMission.Duration}");
        currentMission.Execute();
        Console.WriteLine(currentMission.GetReport());
        Console.WriteLine();
      }
    }
  }
}