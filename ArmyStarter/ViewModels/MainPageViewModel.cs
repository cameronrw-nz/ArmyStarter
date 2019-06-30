using ArmyStarter.Models;
using ArmyStarter.Providers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IArmyProvider _armyProvider;
        private ObservableCollection<ArmyViewModel> _armies;
        private ArmyViewModel _selectedArmy;

        public MainPageViewModel(IArmyProvider armyProvider)
        {
            _armyProvider = armyProvider;

            Armies = new ObservableCollection<ArmyViewModel>();
            InitiliseMainPage();
        }

        public ObservableCollection<ArmyViewModel> Armies
        {
            get
            {
                return _armies;
            }

            set
            {
                _armies = value;
                OnPropertyChanged();
            }
        }

        public ArmyViewModel SelectedArmy
        {
            get
            {
                return _selectedArmy;
            }

            set
            {
                _selectedArmy = value;
                OnPropertyChanged();
            }
        }

        public void CreateNewArmy()
        {
            var newArmy = new ArmyViewModel(new Army());

            Armies.Add(newArmy);

            SelectedArmy = newArmy;
        }

        internal void RemoveArmy()
        {
            _armies.Remove(SelectedArmy);
            SelectedArmy = null;

            OnPropertyChanged(nameof(Armies));
        }

        internal void CopyArmy()
        {
            Army army = SelectedArmy.Army;
            army.ArmyUnits.Clear();

            var armyItems = new List<ArmyUnit>();
            foreach (ArmyUnitViewModel armyItemVM in SelectedArmy.ArmyUnits)
            {
                ArmyUnit armyItem = armyItemVM.ArmyUnit;

                armyItem.Options = armyItemVM.Options.Select(option => option.Option).ToList();

                army.ArmyUnits.Add(armyItemVM.ArmyUnit);
            }

            var copiedArmy = new ArmyViewModel(StaticHelper.DeepClone(army));

            Armies.Add(copiedArmy);

            SelectedArmy = copiedArmy;
        }

        public void RefreshProperties()
        {
            OnPropertyChanged(nameof(SelectedArmy));
            OnPropertyChanged(nameof(Armies));
        }

        private async void InitiliseMainPage()
        {
            IEnumerable<Army> armies = _armyProvider.GetArmies();

            foreach (Army army in armies)
            {
                Armies.Add(new ArmyViewModel(army));
            }
        }

        public async void SaveArmies()
        {
            var armies = new List<Army>();
            foreach (ArmyViewModel armyVM in Armies)
            {
                var army = armyVM.Army;
                army.ArmyUnits.Clear();

                var armyUnits = new List<ArmyUnit>();
                foreach (ArmyUnitViewModel armyUnitVM in armyVM.ArmyUnits)
                {
                    ArmyUnit armyUnit = armyUnitVM.ArmyUnit;

                    armyUnit.ArmyId = army.ArmyId;
                    armyUnit.Options = armyUnitVM.Options.Select(option => option.Option).ToList();

                    army.ArmyUnits.Add(armyUnitVM.ArmyUnit);
                }
            }

            _armyProvider.SaveArmies(armies);
        }
    }
}
