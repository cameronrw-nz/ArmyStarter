﻿using System;
using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class Army
    {
        public Army()
        {
            ArmyId = Guid.NewGuid();
        }

        public string Name { get; set; }

        public List<ArmyUnit> ArmyUnits { get; set; } = new List<ArmyUnit>();

        public Guid ArmyId { get; set; }
    }
}
