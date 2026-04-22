using System;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peopleCount;
    private int _baseDuration = 5;
    private int _peoplePerDay = 10;

    public RescueMission(int peopleCount) {
      Name = "Спасательная миссия";
      Duration = _baseDuration + peopleCount / _peoplePerDay;
      _peopleCount = peopleCount;
    }

    public override string Execute() {
      return $"{Name}: эвакуация {_peopleCount} человек";
    }

    public override string GetReport() {
      return $"{Name}: спасено {_peopleCount} человек";
    }
  }
}