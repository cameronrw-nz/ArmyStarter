
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Models
{
    public class Option
    {
        public Guid OptionId { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Link { get; set; }
    }
}
