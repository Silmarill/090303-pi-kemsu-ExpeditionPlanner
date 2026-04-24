using System;

namespace ExpeditionPlanner.Models {
  // Класс для спасательных миссий, которые могут быть частью экспедиции
  public class RescueMission : Mission {
    private int _peopleCount;
    private int _baseRescueDays = 5;
    private int _peoplePerExtraDay = 10;

    public RescueMission(int peopleCount) {
      _peopleCount = peopleCount;
      Name = "Спасательная миссия";

      // Чем больше людей — тем дольше
      Duration = _baseRescueDays + peopleCount / _peoplePerExtraDay;
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