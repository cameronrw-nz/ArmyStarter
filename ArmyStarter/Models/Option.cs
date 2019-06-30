using System;

namespace ArmyStarter.Models
{
    public class Option : Item
    {
        public Option()
        {
            OptionId = new Guid();
        }

        public Guid OptionId { get; }
    }
}
