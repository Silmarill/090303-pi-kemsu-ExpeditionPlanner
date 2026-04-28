using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int BaseDuration = 5;
    private const int PeoplePerExtraDay = 10;
    private readonly int peopleCount;

    public RescueMission(int peopleCount) {
      this.peopleCount = peopleCount;
      Name = "🚀 Спасательная миссия";
      Duration = BaseDuration + (this.peopleCount / PeoplePerExtraDay);
    }

    public override void Execute() {
      Console.WriteLine(" Спасательная операция: эвакуация " + peopleCount + " человек");
    }

    public override string GetReport() {
      return " Спасательная миссия: спасено " + peopleCount + " человек";
    }
  }
}
