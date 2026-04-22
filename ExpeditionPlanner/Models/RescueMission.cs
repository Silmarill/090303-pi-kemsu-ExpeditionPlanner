using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {

    private static int _peopleCount;
    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      _name = "Спасательная миссия";
      Duration = 5 + (_peopleCount / 10);
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция по эвакуации {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {_name}: успешно не потеряно {_peopleCount} человек";
    }
  }
}