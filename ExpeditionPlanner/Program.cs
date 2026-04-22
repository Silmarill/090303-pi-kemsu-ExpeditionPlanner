using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

// Создаём фабрики разных типов
List<MissionFactory> factories = [new RandomMissionFactory()];

Console.WriteLine("=== План миссий на месяц ===\n");

foreach (MissionFactory factory in factories) {
  // Фабричный метод создаёт миссию, но мы не знаем, какого именно типа - метож у всех одинаковый
  Mission mission = factory.CreateMission();

  Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
  Console.WriteLine(mission.Execute());
  Console.WriteLine(mission.GetReport());
  Console.WriteLine();
}

// Легко добавить новую миссию, не меняя существующий код!
// MissionFactory newFactory = new DiplomaticMissionFactory(); // придумаем позже
// Mission diplomaticMission = newFactory.CreateMission();
// diplomaticMission.Execute();