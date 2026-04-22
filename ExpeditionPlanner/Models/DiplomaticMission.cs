using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private const int DefaultDiplomaticDuration = 20;
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = DefaultDiplomaticDuration;
    }

    public override void Execute() {
      Console.WriteLine(" 🤝 Переговоры с инопланетной цивилизацией, подписание договора ");
    }

    public override string GetReport() {
      return " Торговые соглашения заключены успешно ";
    }
  }
}