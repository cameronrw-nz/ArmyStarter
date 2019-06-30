using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmyStarter.Models
{
    public class ArmyUnit : Item
    {
        public ArmyUnit() : base()
        {
        }

        public Guid? ArmyId { get; set; }

        public int PointsValue { get; set; }

        public int TotalCost
        {
            get
            {
                return Cost + (Options != null ? Options.Sum(option => option.Cost) : 0);
            }
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        public List<Option> Options { get; set; } = new List<Option>();

        public Guid? ArmyUnitId { get; set; }
    }
}
