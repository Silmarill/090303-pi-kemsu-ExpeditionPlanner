using System;
using System.Collections.Generic;

// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Models;
using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  public class Program {
    static void Main() {

      int rescueMissionSuccessChance = 50;

      // Создаём фабрики разных типов
      List<MissionFactory> factories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(rescueMissionSuccessChance),
        new RandomMissionFactory()
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      foreach (var factoryItem in factories) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метод у всех одинаковый
        Mission mission = factoryItem.CreateMission();

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
