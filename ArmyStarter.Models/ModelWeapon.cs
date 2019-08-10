using System;

namespace ArmyStarter.Models
{
    public class ModelWeapon
    {
        public Guid ModelId { get; set; }

        public Guid WeaponId { get; set; }

        public int PointsValue { get; set; }

        public virtual Model Model { get; set; }

        public virtual Weapon Weapon{ get; set; }

    }
}