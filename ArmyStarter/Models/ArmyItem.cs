using System.Collections.Generic;
using System.Linq;

namespace ArmyStarter.Models
{
    public class ArmyItem : Item
    {
        public ArmyItem() : base()
        {
        }

        public int PointsValue { get; set; }

        public int TotalCost
        {
            get
            {
                return Cost + Options.Sum(option => option.Cost);
            }
        }

        public List<string> Notes { get; set; }

        public List<Option> Options { get; set; } = new List<Option>();
    }
}
