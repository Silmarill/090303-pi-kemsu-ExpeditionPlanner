using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      // Объявление фабрик миссий (в список)
      List<MissionFactory> factories;

      factories = new List<MissionFactory>
      {
        // Оставлена одна рандомная фабрика, которая может создавать разные миссии
        new RandomMissionFactory()
      };

      Console.WriteLine("=== План миссии на месяц ===\n");

      // Выполнение миссий, созданных фабриками
      foreach (MissionFactory factory in factories) {
        // Создание миссии через фабрику
        Mission mission;
        mission = factory.CreateMission();

        // Выполнение миссии и вывод отчета
        Console.WriteLine($"Миссия: {mission.Name} (продолжительность: {mission.Duration} дней");
        mission.Execute();
        Console.WriteLine(mission.GetReport());
        Console.WriteLine();
      }
    }
  }
}