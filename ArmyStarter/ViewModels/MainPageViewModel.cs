using ArmyStarter.Models;
using ArmyStarter.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IArmyProvider _armyProvider;
        private readonly IArmyUnitProvider _armyUnitProvider;
        private ObservableCollection<ArmyViewModel> _armies;
        private ArmyViewModel _selectedArmy;

        public MainPageViewModel() : this(new ArmyProvider())
        {

        }

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
                if (_selectedArmy != null && _selectedArmy.Army.ArmyId != null && _selectedArmy.ArmyUnits.Count == 0)
                {
                    _selectedArmy.PopulateArmyUnits();
                }

                OnPropertyChanged();
            }
        }

        public void CreateNewArmy()
        {
            var newArmy = new ArmyViewModel() { Army = new Army() };

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

            var copiedArmy = new ArmyViewModel() { Army = StaticHelper.DeepClone(army) };

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
            IEnumerable<Army> armies = await _armyProvider.GetArmies();

            foreach (Army army in armies)
            {
                Armies.Add(new ArmyViewModel { Army = army });
            }
        }

        public async void SaveArmies()
        {
            var armies = new List<Army>();
            foreach (ArmyViewModel armyVM in Armies)
            {
                Army army = armyVM.Army;
                if (army.ArmyId == null)
                {
                    army.ArmyId = Guid.NewGuid();
                }
                army.ArmyUnits.Clear();

                var armyUnits = new List<ArmyUnit>();
                foreach (ArmyUnitViewModel armyUnitVM in armyVM.ArmyUnits)
                {
                    ArmyUnit armyUnit = armyUnitVM.ArmyUnit;
                    if (armyUnit.ArmyUnitId == null)
                    {
                        armyUnit.ArmyUnitId = Guid.NewGuid();
                    }

                    armyUnit.ArmyId = army.ArmyId;
                    armyUnit.Options = armyUnitVM.Options.Select(option => option.Option).ToList();

                    army.ArmyUnits.Add(armyUnitVM.ArmyUnit);
                }
            }

            _armyProvider.SaveArmies(armies);
        }
    }
}
