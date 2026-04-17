using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionPlanner.Models {
  public class RescueMission : Mission {
    private int _peoplecount;

    public RescueMission(int peoplecount) {
      _peoplecount = peoplecount;
      Name = "Спасательная миссия";
      Duration = (5 + peoplecount) / 10;
    }

    public override void Execute() {
      Console.WriteLine($"Спасательная операция: эвакуация {_peoplecount} человек");
    }

    public override string GetReport() {
      return $"Спасательная миссия: спасено {_peoplecount} человек";
    }
  }
}
