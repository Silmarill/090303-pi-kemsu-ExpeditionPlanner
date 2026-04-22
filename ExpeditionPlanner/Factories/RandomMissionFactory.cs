using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories
{
  public class RandomMissionFactory : MissionFactory
  {
    private List<MissionFactory> _factories;
    private Random _random;

    public RandomMissionFactory(
      int defaultEvacuationPeopleCount,
      int rescuePreparationDaysBase,
      int rescuePeopleEvacuatedPerDay,
      int cargoMissionDurationDays,
      int combatMissionDurationDays,
      int diplomaticMissionDurationDays,
      int explorationMissionDurationDays,
      int cargoTonsDelivered,
      int combatEnemyShipsDestroyed,
      int diplomaticTradeAgreementsCount,
      int explorationNewStarSystemsDiscovered)
    {
      _random = new Random();
      _factories = new List<MissionFactory>
      {
        new RescueMissionFactory(
          defaultEvacuationPeopleCount,
          rescuePreparationDaysBase,
          rescuePeopleEvacuatedPerDay),
        new CargoMissionFactory(cargoMissionDurationDays, cargoTonsDelivered),
        new CombatMissionFactory(combatMissionDurationDays, combatEnemyShipsDestroyed),
        new DiplomaticMissionFactory(diplomaticMissionDurationDays, diplomaticTradeAgreementsCount),
        new ExplorationMissionFactory(explorationMissionDurationDays, explorationNewStarSystemsDiscovered),
      };
    }

    public override Mission CreateMission()
    {
      int randomIndex;
      randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}
