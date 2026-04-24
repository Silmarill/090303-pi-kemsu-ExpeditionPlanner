using ExpeditionPlanner.Factories;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      RandomMissionFactory randomFactory = new RandomMissionFactory(200);
      System.Console.WriteLine("=== План миссий на месяц ===\n");
      for (int missionIndex = 0; missionIndex < 5; missionIndex++) {
        Models.Mission currentMission = randomFactory.CreateMission();
        System.Console.WriteLine($"Миссия: {currentMission.Name} (длительность: {currentMission.Duration} дней)");
        currentMission.Execute();
        System.Console.WriteLine(currentMission.GetReport());
        System.Console.WriteLine();
      }
    }
  }
}