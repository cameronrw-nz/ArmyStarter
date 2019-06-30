using ArmyStarter.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class ArmyViewModel : ViewModelBase
    {
        private string _armyName;
        private ObservableCollection<ArmyUnitViewModel> _armyItems;
        private ArmyUnitViewModel _selectedArmyItem;

        public ArmyViewModel()
        {
        }

        public ArmyViewModel(Army army)
        {
            _armyName = army.Name;

            Army = army;
            ArmyUnits = new ObservableCollection<ArmyUnitViewModel>(army.ArmyUnits.Select(armyItem =>
            {
                var armyVM = new ArmyUnitViewModel(armyItem);
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
                var armyCost = ArmyUnits.Select(armyItem => armyItem.TotalCost).ToArray().Sum();
                return $"{armyCost} THB";
            }
        }

        public string ArmyPointsValue
        {
            get
            {
                var totalPoints = ArmyUnits.Select(armyItem => armyItem.PointsValue).ToArray().Sum();
                return $"{totalPoints} Pts";
            }
        }

        public ObservableCollection<ArmyUnitViewModel> ArmyUnits
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

        public ArmyUnitViewModel SelectedArmyItem
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
            var newArmyItem = new ArmyUnitViewModel(new ArmyUnit());
            newArmyItem.PropertyChanged += SelectedArmyItem_PropertyChanged;

            ArmyUnits.Add(newArmyItem);

            SelectedArmyItem = newArmyItem;
        }

        internal void RemoveArmyItem()
        {
            _armyItems.Remove(SelectedArmyItem);
            SelectedArmyItem = null;

            OnPropertyChanged(nameof(ArmyUnits));
            OnPropertyChanged(nameof(ArmyCost));
            OnPropertyChanged(nameof(ArmyPointsValue));
        }

        internal void CopyArmyItem()
        {
            var armyItem = SelectedArmyItem.ArmyUnit;
            armyItem.Options = SelectedArmyItem.Options.Select(option => option.Option).ToList();

            var copiedArmyItem = new ArmyUnitViewModel(StaticHelper.DeepClone(armyItem));

            ArmyUnits.Add(copiedArmyItem);

            SelectedArmyItem = copiedArmyItem;

            OnPropertyChanged(nameof(ArmyCost));
            OnPropertyChanged(nameof(ArmyPointsValue));
        }

        private void SelectedArmyItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ArmyCost));
            OnPropertyChanged(nameof(ArmyPointsValue));
        }
    }
}
