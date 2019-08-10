using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStarter.Models
{
    public class PlanModel
    {
        public Guid PlanModelId { get; set; }

        public Guid ModelId { get; set; }

        public virtual IEnumerable<PlanModelWeapon> PlanModelWeapons { get; set; }

        public virtual Model Model { get; set; }
    }
}
