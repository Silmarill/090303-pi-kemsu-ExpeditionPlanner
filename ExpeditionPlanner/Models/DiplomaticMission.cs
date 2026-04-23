using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    private const int DefaultDurationDays = 20;

    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = DefaultDurationDays;
    }

    public override string Execute() {
      return " Переговоры с инопланетной цивилизацией, подписание договора";
    }

    public override string GetReport() {
      return " Дипломатическая миссия: заключено 3 торговых соглашения";
    }
  }
}
