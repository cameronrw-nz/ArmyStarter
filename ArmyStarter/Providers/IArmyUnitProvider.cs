using ArmyStarter.Models;
using System;
using System.Collections.Generic;

namespace ArmyStarter.Providers
{
    public interface IArmyUnitProvider
    {
        IEnumerable<ArmyUnit> GetArmyUnitsForArmy(Guid armyId);
    }
}
