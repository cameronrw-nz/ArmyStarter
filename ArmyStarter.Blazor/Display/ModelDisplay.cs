using ArmyStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Display
{
    public class ModelDisplay
    {
        private int numberOfModels;

        public ModelDisplay(Model model)
        {
            Model = model;
            Console.WriteLine(NumberOfModels);
            NumberOfModels = 1;

        }

        public Model Model { get; }

        public int NumberOfModels
        {
            get
            {
                Console.WriteLine("get number");
                return numberOfModels;
            }
            set
            {
                numberOfModels = value;
                Console.WriteLine("Set number");

            }
        }
    }
}
