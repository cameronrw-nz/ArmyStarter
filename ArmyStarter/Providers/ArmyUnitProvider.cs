using ArmyStarter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public class ArmyUnitProvider
    {
        public IEnumerable<ArmyUnit> GetArmies()
        {
            var armiesStringResponse = ApiFramework.ApiGetStringResponse(Constants.ArmyUnitsController).Result;
            IEnumerable<ArmyUnit> armies = JsonConvert.DeserializeObject<IEnumerable<ArmyUnit>>(armiesStringResponse);
            return armies;
        }
    }
}
