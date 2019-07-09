using ArmyStarter.Models;
using ArmyStarter.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class PlanArmyViewModel : ViewModelBase
    {
        private readonly IArmyUnitProvider _armyUnitProvider;
        private ObservableCollection<PlanUnitViewModel> _planUnits;
        private PlanUnitViewModel _selectedArmyItem;
        private PlanArmy army;

        public PlanArmyViewModel() : this(new ArmyUnitProvider())
        {
        }

        public PlanArmyViewModel(IArmyUnitProvider armyUnitProvider)
        {
            _armyUnitProvider = armyUnitProvider;

            PlanUnits = new ObservableCollection<PlanUnitViewModel>();
        }

        public PlanArmy PlanArmy
        {
            get
            {
                return army;
            }
            set
            {
                army = value;
                OnPropertyChanged(nameof(ArmyName));
                OnPropertyChanged(nameof(ArmyPointsValue));
                OnPropertyChanged(nameof(ArmyCost));
            }
        }

        public string ArmyName
        {
            get
            {
                return PlanArmy?.Name;
            }

            set
            {
                PlanArmy.Name = value;
                OnPropertyChanged();
            }
        }

        public string ArmyCost
        {
            get
            {
                var armyCost = PlanUnits?.Select(armyItem => armyItem.TotalCost).ToArray().Sum();
                return $"{armyCost ?? 0} THB";
            }
        }

        public string ArmyPointsValue
        {
            get
            {
                var totalPoints = PlanUnits?.Select(armyItem => armyItem.PointsValue).ToArray().Sum();
                return $"{totalPoints ?? 0} Pts";
            }
        }

        public ObservableCollection<PlanUnitViewModel> PlanUnits
        {
            get
            {
                return _planUnits;
            }

            set
            {
                _planUnits = value;
                OnPropertyChanged();
            }
        }

        public async void PopulateArmyUnits()
        {
            IEnumerable<PlanUnit> armyUnits = await _armyUnitProvider.GetArmyUnitsForArmy((Guid)PlanArmy.PlanArmyId);
            PlanUnits = new ObservableCollection<PlanUnitViewModel>(armyUnits.Select(armyItem =>
            {
                var armyVM = new PlanUnitViewModel(armyItem);
                armyVM.PropertyChanged += SelectedArmyItem_PropertyChanged;
                return armyVM;
            }));

            OnPropertyChanged(nameof(ArmyPointsValue));
            OnPropertyChanged(nameof(ArmyCost));
        }

        public PlanUnitViewModel SelectedArmyUnit
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
            var newArmyUnit = new PlanUnitViewModel(new PlanUnit());
            newArmyUnit.PropertyChanged += SelectedArmyItem_PropertyChanged;

            PlanUnits.Add(newArmyUnit);

            SelectedArmyUnit = newArmyUnit;
        }

        internal void RemoveArmyItem()
        {
            _planUnits.Remove(SelectedArmyUnit);
            SelectedArmyUnit = null;

            OnPropertyChanged(nameof(PlanUnits));
            OnPropertyChanged(nameof(ArmyCost));
            OnPropertyChanged(nameof(ArmyPointsValue));
        }

        internal void CopyArmyItem()
        {
            var armyItem = SelectedArmyUnit.PlanUnit;
            armyItem.Options = SelectedArmyUnit.Options.Select(option => option.Option).ToList();

            var copiedArmyItem = new PlanUnitViewModel(StaticHelper.DeepClone(armyItem));

            PlanUnits.Add(copiedArmyItem);

            SelectedArmyUnit = copiedArmyItem;

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
