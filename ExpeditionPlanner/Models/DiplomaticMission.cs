using System;

namespace ExpeditionPlanner.Models {
  public class DiplomaticMission : Mission {
    // Constants (avoid magic numbers)
    private const int missionDurationDays = 20;
    private const int agreementsCount = 3;

    public DiplomaticMission() {
      // Block: initialization
      name = "Diplomatic mission";
      duration = missionDurationDays;
    }

    public override void Execute() {
      // Block: mission execution output
      Console.WriteLine("Negotiations with alien civilization and treaty signing");
    }

    public override string GetReport() {
      // Block: report generation
      string report;

      report = $"{name}: {agreementsCount} trade agreements signed";

      return report;
    }
  }
}