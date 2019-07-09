using ArmyStarter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public class ArmyUnitProvider : IArmyUnitProvider
    {
        public async Task<IEnumerable<PlanUnit>> GetArmyUnitsForArmy(Guid armyId)
        {
            string armyUnitUrlString = $"{Constants.ArmyUnitsController}/planArmyId={armyId.ToString()}";
            string armiesStringResponse = await ApiFramework.ApiGetStringResponse(armyUnitUrlString);
            IEnumerable<PlanUnit> planUnits = JsonConvert.DeserializeObject<IEnumerable<PlanUnit>>(armiesStringResponse);
            return planUnits;
        }
    }
}
