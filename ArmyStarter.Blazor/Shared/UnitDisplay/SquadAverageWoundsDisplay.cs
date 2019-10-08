using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Shared.UnitDisplay
{
    public class SquadAverageWoundsDisplay
    {
        public string Name { get; set; }

        public string ShootingWounds { get; set; }

        public string ShootingKilled { get; set; }

        public string MeleeWounds { get; set; }

        public string MeleeKilled { get; set; }

        public string StatsString { get; set; }
    }
}
