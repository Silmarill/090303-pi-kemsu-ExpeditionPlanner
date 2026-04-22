using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main() {
      int peopleCount = 50;
      // Создаём фабрики разных типов
      List<MissionFactory> factories = new List<MissionFactory>
      {
            new RandomMissionFactory(),
            new RandomMissionFactory(),
            new RandomMissionFactory(),
            new RandomMissionFactory()
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      foreach (MissionFactory factory in factories) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метож у всех одинаковый
        Mission mission = factory.CreateMission();

        Console.WriteLine($"Миссия: {mission._name} (длительность: {mission.Duration} дней)");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }

      // Push Test Actions
      // Легко добавить новую миссию, не меняя существующий код!
      // MissionFactory newFactory = new DiplomaticMissionFactory(); // придумаем позже
      // Mission diplomaticMission = newFactory.CreateMission();
      // diplomaticMission.Execute();
    }
  }
}
