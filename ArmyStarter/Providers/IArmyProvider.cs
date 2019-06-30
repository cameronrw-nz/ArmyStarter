using ArmyStarter.Models;
using System.Collections.Generic;

namespace ArmyStarter.Providers
{
    public interface IArmyProvider
    {
        IEnumerable<Army> GetArmies();

        void SaveArmies(IEnumerable<Army> armies);
    }
}
