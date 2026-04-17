using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    // Публичные константы вместо магических чисел
    public int BaseDuration = 5;
    public int PeoplePerDurationUnit = 10;

    public int PeopleCount { get; set; }

    public RescueMission(int peopleCount) {
      PeopleCount = peopleCount;
    }

    public string Name => "Спасательная миссия";
    public int Duration => BaseDuration + PeopleCount / PeoplePerDurationUnit;

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {PeopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {PeopleCount} человек";
    }
  }
}