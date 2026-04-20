using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    
    public RescueMission(int peopleCount) {
      Name = "Спасательная миссия";
      Duration = 5 + peopleCount / 10;
      _peopleCount = peopleCount;
    }

    public override void Execute() {
      Console.WriteLine($"{Name}: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $"{Name}: спасено {_peopleCount} человек";
    }
  }
}