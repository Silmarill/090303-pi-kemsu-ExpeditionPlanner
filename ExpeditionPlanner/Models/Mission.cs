namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    public string Name;
    public int Duration; // в днях

    public abstract string Execute();

    public abstract string GetReport();
  }
}
