using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmyStarter.Models
{
    public class ArmyUnit : Item
    {
        public ArmyUnit() : base()
        {
            ArmyUnitId = Guid.NewGuid();
        }

        public Guid ArmyId { get; set; }

        public int PointsValue { get; set; }

        public int TotalCost
        {
            get
            {
                return Cost + Options.Sum(option => option.Cost);
            }
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        public List<Option> Options { get; set; } = new List<Option>();

        public Guid ArmyUnitId { get; set; }
    }
}
