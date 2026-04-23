using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = 5 + _peopleCount / 10;
    }

    public override void Execute() {
      Console.WriteLine(" Спасательная операция: эвакуация " + _peopleCount + " человек");
    }

    public override string GetReport() {
      return " Спасательная миссия: спасено " + _peopleCount + " человек";
    }
  }
}
