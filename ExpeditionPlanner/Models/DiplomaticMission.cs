using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  
  public class DiplomaticMission: Mission {
    public DiplomaticMission(): base("Дипломатическая миссия", 20){}

    public override void Execute() {
      Console.WriteLine("Переговоры с инопланетной цивилизцацией, подписание договора");

    }
    public override string GetReport() {
      return "Дипломатическая миссия: заключено 3 торговых соглошения";
      
    }
  }
}
