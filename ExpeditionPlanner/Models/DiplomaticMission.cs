using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public DiplomaticMission() {
      _name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine("🤝 Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return $"📃 {_name}: заключено 3 торговых соглашения";
    }

  }
}
