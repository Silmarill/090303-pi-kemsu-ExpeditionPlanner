using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();
    private int rescueBasePreparationDays;
    private int rescuePeopleEvacuatedPerDay;
    private int cargoMissionDurationDays;
    private int combatMissionDurationDays;
    private int diplomaticMissionDurationDays;
    private int explorationMissionDurationDays;
    private int cargoDeliveredTons;
    private int combatDestroyedEnemyShips;
    private int diplomaticTradeAgreements;
    private int explorationNewStarSystems;

    public RandomMissionFactory(int defaultEvacuationPeopleCount) {
      _factories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(5),
        new CombatMissionFactory(12),
        new CargoMissionFactory(500),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(100)
      };
    }

    public RandomMissionFactory(int defaultEvacuationPeopleCount, int rescueBasePreparationDays, int rescuePeopleEvacuatedPerDay, int cargoMissionDurationDays, int combatMissionDurationDays, int diplomaticMissionDurationDays, int explorationMissionDurationDays, int cargoDeliveredTons, int combatDestroyedEnemyShips, int diplomaticTradeAgreements, int explorationNewStarSystems) : this(defaultEvacuationPeopleCount) {
      this.rescueBasePreparationDays = rescueBasePreparationDays;
      this.rescuePeopleEvacuatedPerDay = rescuePeopleEvacuatedPerDay;
      this.cargoMissionDurationDays = cargoMissionDurationDays;
      this.combatMissionDurationDays = combatMissionDurationDays;
      this.diplomaticMissionDurationDays = diplomaticMissionDurationDays;
      this.explorationMissionDurationDays = explorationMissionDurationDays;
      this.cargoDeliveredTons = cargoDeliveredTons;
      this.combatDestroyedEnemyShips = combatDestroyedEnemyShips;
      this.diplomaticTradeAgreements = diplomaticTradeAgreements;
      this.explorationNewStarSystems = explorationNewStarSystems;
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}