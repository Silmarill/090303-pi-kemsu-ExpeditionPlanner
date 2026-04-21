using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  internal class DiplomaticMission : Mission {
    public DiplomaticMission() {
      Name = "Дипломатическая экспедиция";
      Duration = 25;
    }

    public override void Execute() {
      Console.WriteLine("Ведение переговоров с инопланетной цивилизацией, подписание мирного договора");
    }

    public override string GetReport() {
      return "Дипломатическая экспедиция: установлены дипломатические отношения с 4 цивилизациями";
    }
  }
}