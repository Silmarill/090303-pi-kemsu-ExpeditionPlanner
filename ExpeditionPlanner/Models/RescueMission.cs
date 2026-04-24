using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int BaseDuration = 5;
    private const int PeoplePerExtraDay = 10;
    private int _peopleCount;

    public RescueMission(int _peopleCount) {
      this._peopleCount = _peopleCount;
      Name = "🚀 Спасательная миссия";
      Duration = BaseDuration + this._peopleCount / PeoplePerExtraDay;
    }

    public override void Execute() {
      Console.WriteLine(" Спасательная операция: эвакуация " + _peopleCount + " человек");
    }

    public override string GetReport() {
      return " Спасательная миссия: спасено " + _peopleCount + " человек";
    }
  }
}
