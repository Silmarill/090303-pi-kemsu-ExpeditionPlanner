using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    public DiplomaticMission() {
      Name = "Дипломатическая миссия";
      Duration = 20;
    }

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизацией");
    }

    public override string GetReport() {
      return $"{Name}: заключено 3 торговых соглашения";
    }

  }
}
