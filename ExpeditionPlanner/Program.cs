using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner {
  class Program {
    static void Main(string[] args) {
      int RandomMissionsCount = 4;
      int RescueMissionPeopleCount = 100;
      int IndexOffsetForDisplay = 1;

      RandomMissionFactory randomMissionFactory;
      randomMissionFactory = new RandomMissionFactory();
      Mission currentMission = null;

      Console.WriteLine("=== Случайные миссии (Задание 3) ===");
      for (int missionIndex = 0; missionIndex < RandomMissionsCount; ++missionIndex) {
        currentMission = randomMissionFactory.CreateMission();
        Console.WriteLine($"[{missionIndex + IndexOffsetForDisplay}] {currentMission.Name} ({currentMission.Duration} дн.)");
        currentMission.Execute();
        Console.WriteLine(currentMission.GetReport());
        Console.WriteLine();
      }

      Console.WriteLine("=== Конкретные фабрики ===");
      List<MissionFactory> concreteFactories = new List<MissionFactory>
      {
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(RescueMissionPeopleCount)
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