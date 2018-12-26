using ArmyStarter.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class ArmyViewModel : ViewModelBase
    {
        private string _armyName;
        private ObservableCollection<ArmyItemViewModel> _armyItems;
        private ArmyItemViewModel _selectedArmyItem;

        public ArmyViewModel(Army army)
        {
            Army = army;
            _armyName = army.Name;
            ArmyItems = new ObservableCollection<ArmyItemViewModel>(army.HQs.Select(armyItem =>
            {
                var armyVM = new ArmyItemViewModel(armyItem);
                armyVM.PropertyChanged += SelectedArmyItem_PropertyChanged;
                return armyVM;
            }));
        }

        public Army Army { get; set; }

        public string ArmyName
        {
            get
            {
                return Army?.Name;
            }

            set
            {
                Army.Name = value;
                OnPropertyChanged();
            }
        }

        public string ArmyCost
        {
            get
            {
                var armyCost = ArmyItems.Select(armyItem => armyItem.TotalCost).ToArray().Sum();
                return $"{armyCost} THB";
            }
        }

        public string ArmyPointsValue
        {
            get
            {
                var totalPoints = ArmyItems.Select(armyItem => armyItem.PointsValue).ToArray().Sum();
                return $"{totalPoints} Pts";
            }
        }

        public ObservableCollection<ArmyItemViewModel> ArmyItems
        {
            get
            {
                return _armyItems;
            }

            set
            {
                _armyItems = value;
                OnPropertyChanged();
            }
        }

        public ArmyItemViewModel SelectedArmyItem
        {
            get
            {
                return _selectedArmyItem;
            }

            set
            {
                _selectedArmyItem = value;
                OnPropertyChanged();
            }
        }

        public void CreateNewArmyItem()
        {
            var newArmyItem = new ArmyItemViewModel(new ArmyItem());
            newArmyItem.PropertyChanged += SelectedArmyItem_PropertyChanged;

            ArmyItems.Add(newArmyItem);

            SelectedArmyItem = newArmyItem;
        }

        private void SelectedArmyItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ArmyCost));
            OnPropertyChanged(nameof(ArmyPointsValue));
        }
    }
}
