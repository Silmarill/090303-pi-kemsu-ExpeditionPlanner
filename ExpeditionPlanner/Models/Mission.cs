namespace ExpeditionPlanner.Models {
  public abstract class Mission {
    // Свойства используются вместо полей, чтобы явно отделить данные от реализации и обеспечить инкапсуляцию
    public string Name { get; set; }
    public int Duration { get; set; }

    // Выполнение миссии
    public abstract void Execute();

    // Отчет о миссии
    public abstract string GetReport();
  }
}