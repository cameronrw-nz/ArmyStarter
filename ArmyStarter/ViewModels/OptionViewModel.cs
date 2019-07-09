using ArmyStarter.Models;

namespace ArmyStarter.ViewModels
{
    public class OptionViewModel : ViewModelBase
    {
        public OptionViewModel(PlanOption option)
        {
            Option = option;
        }

        public PlanOption Option { get; set; }

        public string Name
        {
            get
            {
                return Option.Name;
            }

            set
            {
                Option.Name = value;
                OnPropertyChanged();
            }
        }

        public int Cost
        {
            get
            {
                return Option.Cost;
            }

            set
            {
                Option.Cost = value;
                OnPropertyChanged();
            }
        }

        public string Link
        {
            get
            {
                return Option.Link;
            }

            set
            {
                Option.Link = value;
                OnPropertyChanged();
            }
        }
    }
}
