
using System;

namespace ArmyStarter.Models
{
    public class PlanOption
    {
        public Guid PlanOptionId { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Link { get; set; }
    }
}
