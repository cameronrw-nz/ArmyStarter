﻿using ArmyStarter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public class ArmyUnitProvider : IArmyUnitProvider
    {
        public async Task<IEnumerable<ArmyUnit>> GetArmyUnitsForArmy(Guid armyId)
        {
            string armyUnitUrlString = $"{Constants.ArmyUnitsController}/armyId={armyId.ToString()}";
            string armiesStringResponse = await ApiFramework.ApiGetStringResponse(armyUnitUrlString);
            IEnumerable<ArmyUnit> armies = JsonConvert.DeserializeObject<IEnumerable<ArmyUnit>>(armiesStringResponse);
            return armies;
        }
    }
}
