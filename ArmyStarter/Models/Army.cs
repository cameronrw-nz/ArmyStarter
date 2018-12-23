using System.Collections.Generic;

namespace ArmyStarter.Models
{
    public class Army
    {
        public Army()
        {
        }

        public string Name { get; set; }

        public List<ArmyItem> HQs { get; set; } = new List<ArmyItem>();
    }
}
