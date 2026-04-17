using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  internal class DiplomaticMission : Mission {
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизацией, подписание договора");
    }

    public override string GetReport() {
      return "Дипломатическая миссия: заключено 3 торговых соглашения";
    }
  }
}