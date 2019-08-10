using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStarter.Models
{
    public class PlanModelWeapon
    {
        public Guid WeaponId { get; set; }

        public Guid PlanModelId { get; set; }

        public int Quantity { get; set; }

        public virtual Weapon Weapon {get; set;}

        public virtual PlanModel PlanModel { get; set; }
    }
}
