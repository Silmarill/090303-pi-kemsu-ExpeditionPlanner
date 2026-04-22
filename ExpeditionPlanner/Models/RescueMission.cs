namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private readonly int _peopleCount;
    private readonly int _baseDuration = 5;
    private readonly int _peoplePerDay = 10;

    public RescueMission(int peopleCount) {
      Name = "Спасательная миссия";
      Duration = _baseDuration + (peopleCount / _peoplePerDay);
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