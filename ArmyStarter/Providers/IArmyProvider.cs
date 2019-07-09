using ArmyStarter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public interface IPlanArmyProvider
    {
        Task<IEnumerable<PlanArmy>> GetArmies();

        void SaveArmies(IEnumerable<PlanArmy> armies);
    }
}
