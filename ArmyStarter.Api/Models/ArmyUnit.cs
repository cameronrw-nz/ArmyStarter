using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Models
{
    public class ArmyUnit
    {
        public Guid ArmyUnitId { get; set; }

        public Guid ArmyId { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Link { get; set; }

        public int PointsValue { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<Option> Options { get; set; }
    }
}