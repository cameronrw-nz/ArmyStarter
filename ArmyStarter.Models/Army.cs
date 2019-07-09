using System;
using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class Army
    {
        public Guid ArmyId { get; set; }

        public string Name { get; set; }

        public IList<Unit> AvailableUnits { get; set; }
    }
}
