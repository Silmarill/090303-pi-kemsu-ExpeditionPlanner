using System;

namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string _name;
    public int Duration; // в днях

    public abstract void Execute();

    public abstract string GetReport();
  }
}
