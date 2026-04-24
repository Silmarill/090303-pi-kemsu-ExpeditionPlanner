namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string Name;
    public int Duration; // в днях

    public abstract void Execute();

    public abstract string GetReport();
  }
}