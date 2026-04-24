namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string Name;
    public int Duration;

    public abstract void Execute();

    public abstract string GetReport();
  }
}