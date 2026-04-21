using System;
using System.Collections.Generic;

// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Models;
using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      MissionFactory randomFactory = new RandomMissionFactory();

      Console.WriteLine("=== План миссий на месяц ===\n");

      int missionCount = 5;

      for (int missionIndex = 0; missionIndex < missionCount; ++missionIndex) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метож у всех одинаковый
        Mission mission = randomFactory.CreateMission();

        Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      // Легко добавить новую миссию, не меняя существующий код!
      //MissionFactory newFactory = new DiplomaticMissionFactory(); // придумаем позже
      //Mission diplomaticMission = newFactory.CreateMission();
      //diplomaticMission.Execute();
    }
  }
}
