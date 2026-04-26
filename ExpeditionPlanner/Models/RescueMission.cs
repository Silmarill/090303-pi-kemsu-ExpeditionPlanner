namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private const int baseDurationDays = 5;
    private const int peoplePerAdditionalDay = 10;
    private readonly int _peopleCount;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";
      Duration = baseDurationDays + (peopleCount / peoplePerAdditionalDay);
    }

    public override string Execute() {
      return $" Спасательная операция: эвакуация {_peopleCount} человек";
    }

    public override string GetReport() {
      return $" Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}