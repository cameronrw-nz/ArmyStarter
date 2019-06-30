using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Models
{
    public class Army
    {
        public Army()
        {
        }

        public Guid ArmyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<ArmyUnit> ArmyUnits { get; set; }
    }
}
