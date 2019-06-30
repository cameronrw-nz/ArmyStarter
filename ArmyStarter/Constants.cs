using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStarter
{
    public static class Constants
    {
        public static string RootUrl = "http://localhost:90/api/";

        public static string ArmiesController = RootUrl + "armies";

        public static string ArmyUnitsController = RootUrl + "armyUnits";
    }
}
