using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;

    public RescueMission(int peopleCount, int preparationDaysBase, int peopleEvacuatedPerDay) {
      Name = "Спасательская миссия";
      _peopleCount = peopleCount;
      Duration = preparationDaysBase + (_peopleCount / peopleEvacuatedPerDay);
    }

    public override void Execute() {
      Console.WriteLine($" Спасательная операция: эвакуация {_peopleCount} человек");
    }

    public override string GetReport() {
      return $" {Name}: спасено {_peopleCount} человек";
    }
  }
}
