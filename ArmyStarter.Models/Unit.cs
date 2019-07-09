using System;
using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class Unit
    {
        public Guid UnitId{ get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Link { get; set; }

        public IList<Model> Models { get; set; }
    }
}
