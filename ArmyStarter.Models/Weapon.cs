using System;
using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class Weapon
    {
        public Guid WeaponId { get; set; }

        public WeaponType WeaponType { get; set; }

        public string Name { get; set; }

        public int Range { get; set; }

        public int Strength { get; set; }

        public int AP { get; set; }

        public int? Attacks { get; set; }

        public int? RandomAttacks { get; set; }

        public int? Damage { get; set; }

        public int? RandomDamage { get; set; }

        public virtual IList<ModelWeapon> ModelWeapons { get; set; }
    }

    public enum WeaponType
    {
        Melee,
        Pistol,
        Assault,
        RapidFire,
        Heavy,
        Macro
    }
}