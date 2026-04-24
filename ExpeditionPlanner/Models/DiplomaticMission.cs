using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {

    private string _reportMessage;
    private const int DefaultDuration = 20;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = DefaultDuration;
      _reportMessage = $"{Name}: заключено 3 торговых соглашения";
    }

    public override void Execute() {
      _reportMessage = "Переговоры с инопланетной цивилизацией";
    }

    public override string GetReport() {
      return _reportMessage;
    }

  }
}
