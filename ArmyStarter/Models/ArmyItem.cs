using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class ArmyItem
    {
        public ArmyItem()
        {
        }

        public string Name { get; set; }

        public int PointsValue { get; set; }

        public int Cost { get; set; }

        public int TotalCost
        {
            get
            {
                return Cost;
            }
        }

        public string Link { get; set; }

        public List<string> Notes { get; set; }

        public List<ArmyItem> Accessories { get; set; }
    }
}
