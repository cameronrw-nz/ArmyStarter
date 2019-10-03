using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStarter.Models
{
    public class PlanModel
    {
        public Guid PlanModelId { get; set; }

        public Guid ModelId { get; set; }

        public int NumberOfModels { get; set; }

        public virtual IList<PlanModelWeapon> PlanModelWeapons { get; set; } = new List<PlanModelWeapon>();

        public virtual Model Model { get; set; }
    }
}
