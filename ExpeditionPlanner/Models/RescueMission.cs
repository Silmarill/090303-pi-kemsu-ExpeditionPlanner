using System;

namespace ExpeditionPlanner.Models {
  // Класс для спасательных миссий, которые могут быть частью экспедиции
  public class RescueMission : Mission {
    private int _peopleCount;
    private int BaseRescueDays = 5;
    private int PeoplePerExtraDay = 10;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";

      // Чем больше людей — тем дольше
      Duration = BaseRescueDays + peopleCount / PeoplePerExtraDay;
    }

    // Выводит информацию о спасении людей
    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peopleCount} человек");
    }

    // Отчет о спасении людей
    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peopleCount} человек";
    }
  }
}