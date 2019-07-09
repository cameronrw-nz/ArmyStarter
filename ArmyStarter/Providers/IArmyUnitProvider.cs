using ArmyStarter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public interface IArmyUnitProvider
    {
        Task<IEnumerable<PlanUnit>> GetArmyUnitsForArmy(Guid armyId);
    }
}
