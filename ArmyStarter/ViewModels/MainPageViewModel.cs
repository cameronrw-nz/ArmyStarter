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
        private readonly IPlanArmyProvider _armyProvider;
        private readonly IArmyUnitProvider _armyUnitProvider;
        private ObservableCollection<PlanArmyViewModel> _armies;
        private PlanArmyViewModel _selectedArmy;

        public MainPageViewModel() : this(new PlanArmyProvider())
        {

        }

        public MainPageViewModel(IPlanArmyProvider armyProvider)
        {
            _armyProvider = armyProvider;

            Armies = new ObservableCollection<PlanArmyViewModel>();
            InitiliseMainPage();
        }

        public ObservableCollection<PlanArmyViewModel> Armies
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

        public PlanArmyViewModel SelectedArmy
        {
            get
            {
                return _selectedArmy;
            }

            set
            {
                _selectedArmy = value;
                if (_selectedArmy != null && _selectedArmy.PlanArmy.PlanArmyId != null && _selectedArmy.PlanUnits.Count == 0)
                {
                    _selectedArmy.PopulateArmyUnits();
                }

                OnPropertyChanged();
            }
        }

        public void CreateNewArmy()
        {
            var newArmy = new PlanArmyViewModel() { PlanArmy = new PlanArmy() };

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
            PlanArmy army = SelectedArmy.PlanArmy;
            army.PlanUnits.Clear();

            var armyItems = new List<PlanUnit>();
            foreach (PlanUnitViewModel armyItemVM in SelectedArmy.PlanUnits)
            {
                PlanUnit armyItem = armyItemVM.PlanUnit;

                armyItem.Options = armyItemVM.Options.Select(option => option.Option).ToList();

                army.PlanUnits.Add(armyItemVM.PlanUnit);
            }

            var copiedArmy = new PlanArmyViewModel() { PlanArmy = StaticHelper.DeepClone(army) };

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
            IEnumerable<PlanArmy> armies = await _armyProvider.GetArmies();

            foreach (PlanArmy army in armies)
            {
                Armies.Add(new PlanArmyViewModel { PlanArmy = army });
            }
        }

        public async void SaveArmies()
        {
            var armies = new List<PlanArmy>();
            foreach (PlanArmyViewModel armyVM in Armies)
            {
                PlanArmy army = armyVM.PlanArmy;
                if (army.PlanArmyId == null)
                {
                    army.PlanArmyId = Guid.NewGuid();
                }
                army.PlanUnits.Clear();

                var armyUnits = new List<PlanUnit>();
                foreach (PlanUnitViewModel armyUnitVM in armyVM.PlanUnits)
                {
                    PlanUnit armyUnit = armyUnitVM.PlanUnit;
                    if (armyUnit.PlanUnitId == null)
                    {
                        armyUnit.PlanUnitId = Guid.NewGuid();
                    }

                    armyUnit.PlanArmyId = army.PlanArmyId;
                    armyUnit.Options = armyUnitVM.Options.Select(option => option.Option).ToList();

                    army.PlanUnits.Add(armyUnitVM.PlanUnit);
                }
            }

            _armyProvider.SaveArmies(armies);
        }
    }
}
