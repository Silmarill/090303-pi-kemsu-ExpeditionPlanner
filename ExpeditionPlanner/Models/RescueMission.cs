using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int peopleCount;

    public RescueMission() {
      Name = "🚀 Спасательная миссия";
      Duration = 5 + peopleCount / 10;
    }

    public override void Execute() {
      Console.WriteLine($" {Name}: эвакуация {peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {peopleCount} человек";
    }
  }
}
