using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    public int baseDuration;
    public int peoplePerExtraDay;

    public RescueMission(int peopleCount) {
      baseDuration = 5;
      peoplePerExtraDay = 10;
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = baseDuration + peopleCount / peoplePerExtraDay;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}