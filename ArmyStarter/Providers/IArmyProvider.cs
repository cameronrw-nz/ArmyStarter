using ArmyStarter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public interface IArmyProvider
    {
        Task<IEnumerable<Army>> GetArmies();

        void SaveArmies(IEnumerable<Army> armies);
    }
}
