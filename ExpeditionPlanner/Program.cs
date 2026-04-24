using System;
using System.Collections.Generic;

// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  public class Program {
    public static void Main() {
      // Создаём фабрики разных типов
      List<MissionFactory> factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(50),
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
