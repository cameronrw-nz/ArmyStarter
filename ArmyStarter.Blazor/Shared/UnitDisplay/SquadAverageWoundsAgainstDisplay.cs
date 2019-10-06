using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Shared.UnitDisplay
{
    public class SquadAverageWoundsAgainstDisplay
    {
        public string Name { get; set; }

        public string WoundsOnUnit { get; set; }

        public string AverageShotsToKill { get; set; }

        public string StatsString { get; set; }
    }
}
