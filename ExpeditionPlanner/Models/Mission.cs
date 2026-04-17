namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string Name { get; protected set; }
    public int Duration { get; protected set; }

    public abstract void Execute();
    public abstract string GetReport();
  }
}