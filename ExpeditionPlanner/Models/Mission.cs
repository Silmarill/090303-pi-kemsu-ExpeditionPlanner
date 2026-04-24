namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string Name { get; set; }

    public int Duration { get; set; }

    public abstract void Execute();

    public abstract string GetReport();
  }
}
