using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    public int baseDuration;
    public int peopleDivider;

    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      baseDuration = 5;
      peopleDivider = 10;

      Name = "Спасательная миссия";
      Duration = (baseDuration + peopleCount) / peopleDivider;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}