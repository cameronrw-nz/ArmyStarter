using System;
using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class PlanUnit
    {
        public Guid PlanUnitId { get; set; }

        public Guid PlanArmyId { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<PlanOption> Options { get; set; }

        public Unit Unit { get; set; }
    }
}