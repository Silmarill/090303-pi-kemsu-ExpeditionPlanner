using System;

namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string name;
    public int _duration; // в днях
    public abstract void Execute();
    public abstract string GetReport();
  }
}
