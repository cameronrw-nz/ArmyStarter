﻿using System;

namespace ArmyStarter.Models
{
    public class Model
    {
        public Guid ModelId { get; set; }

        public string Name { get; set; }

        public int PointsValue { get; set; }

        public int? Movement { get; set; }

        public int? WeaponSkill { get; set; }

        public int? BallisticSkill { get; set; }

        public int Strength { get; set; }

        public int Toughness { get; set; }

        public int Wounds { get; set; }

        public int Attacks { get; set; }

        public int LeaderShip { get; set; }

        public int? ArmourSave { get; set; }

        public int? InvulnerableSave { get; set; }

        public int? FeelNoPainSave { get; set; }
    }
}