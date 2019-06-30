using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Models
{
    public class Army
    {
        public Army()
        {
            ArmyId = Guid.NewGuid();
        }

        public string Name { get; set; }

        public Guid ArmyId { get; set; }
    }
}
