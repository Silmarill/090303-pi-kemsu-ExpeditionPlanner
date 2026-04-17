using ExpeditionPlanner.Factories;
// Обратите внимание на совпадение пространств имен и папок
using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      Console.OutputEncoding = Encoding.UTF8;
      // Создаём фабрики разных типов
      List<MissionFactory> factories = new List<MissionFactory>
      {
            new ExplorationMissionFactory(),
            new CombatMissionFactory(),
            new CargoMissionFactory(),
            new DiplomaticMissionFactory()
        };

      Console.WriteLine("=== План миссий на месяц ===\n");

      foreach (var factory in factories) {
        // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метож у всех одинаковый
        Mission mission = factory.CreateMission();

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
