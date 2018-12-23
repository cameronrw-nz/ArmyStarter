using ArmyStarter.Models;

namespace ArmyStarter.ViewModels
{
    public class ArmyItemViewModel : ViewModelBase
    {
        public ArmyItemViewModel(ArmyItem armyItem)
        {
            ArmyItem = armyItem;
        }

        public ArmyItem ArmyItem { get; set; }

        public string Name
        {
            get
            {
                return ArmyItem.Name;
            }

            set
            {
                ArmyItem.Name = value;
                OnPropertyChanged();
            }
        }

        public int PointsValue
        {
            get
            {
                return ArmyItem.PointsValue;
            }

            set
            {
                ArmyItem.PointsValue = value;
                OnPropertyChanged();
            }
        }

        public int Cost
        {
            get
            {
                return ArmyItem.Cost;
            }

            set
            {
                ArmyItem.Cost = value;
                OnPropertyChanged();
            }
        }

        public string Link
        {
            get
            {
                return ArmyItem.Link;
            }

            set
            {
                ArmyItem.Link = value;
                OnPropertyChanged();
            }
        }
    }
}