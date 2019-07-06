using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Models
{
    public class PlanArmy
    {
        public PlanArmy()
        {
        }

        public Guid PlanArmyId { get; set; }

        public Army Army { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<PlanUnit> PlanUnits { get; set; }
    }
}
