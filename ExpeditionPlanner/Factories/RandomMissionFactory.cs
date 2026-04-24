namespace ExpeditionPlanner.Factories {
  using System;
  using System.Collections.Generic;
  using ExpeditionPlanner.Models;

  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();

    public RandomMissionFactory(
        int defaultEvacuationPeopleCount,
        int rescueBasePreparationDays,
        int rescuePeopleEvacuatedPerDay,
        int cargoMissionDurationDays,
        int combatMissionDurationDays,
        int diplomaticMissionDurationDays,
        int explorationMissionDurationDays,
        int cargoDeliveredTons,
        int combatDestroyedEnemyShips,
        int diplomaticTradeAgreements,
        int explorationNewStarSystems) {
      _factories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(explorationMissionDurationDays, explorationNewStarSystems),
                new CombatMissionFactory(combatMissionDurationDays, combatDestroyedEnemyShips),
                new CargoMissionFactory(cargoMissionDurationDays, cargoDeliveredTons),
                new DiplomaticMissionFactory(diplomaticMissionDurationDays, diplomaticTradeAgreements),
                new RescueMissionFactory(defaultEvacuationPeopleCount, rescueBasePreparationDays, rescuePeopleEvacuatedPerDay)
            };
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}