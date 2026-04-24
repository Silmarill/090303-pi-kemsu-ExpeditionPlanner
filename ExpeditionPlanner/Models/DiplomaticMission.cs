using System;
namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = 20;
    }
    public override void Execute() {
    }
    public override string GetReport() {
      return $" {Name}: заключено 3 торговых соглашения";
    }
    public override string GetExecutionMessage() {
      return "Переговоры с инопланетной цивилизацией, подписание договора";
    }
  }
}