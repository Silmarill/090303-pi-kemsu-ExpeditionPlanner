using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private readonly int _missionDurationDays = 20;
    private readonly int _agreementsCount = 3;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = _missionDurationDays;
    }

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизацией и подписание договора");
    }

    public override string GetReport() {
      return $"{Name}: {_agreementsCount} подписанных торговых соглашений";
    }
  }
}