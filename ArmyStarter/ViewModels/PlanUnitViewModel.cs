using ArmyStarter.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class PlanUnitViewModel : ViewModelBase
    {
        private OptionViewModel _selectedOption;
        private ObservableCollection<OptionViewModel> _options;

        public PlanUnitViewModel(PlanUnit planUnit)
        {
            PlanUnit = planUnit;
            if (planUnit.Options == null)
            {
                Options = new ObservableCollection<OptionViewModel>();
            }
            else
            {
                Options = new ObservableCollection<OptionViewModel>(planUnit.Options.Select(option => new OptionViewModel(option)));
            }
        }

        public PlanUnit PlanUnit { get; set; }

        public string Name
        {
            get
            {
                return PlanUnit.Unit?.Name;
            }

            set
            {
                PlanUnit.Unit.Name = value;
                OnPropertyChanged();
            }
        }

        public int PointsValue
        {
            get
            {
                return 0;
            }

            set
            {
                OnPropertyChanged();
            }
        }

        public int? Cost
        {
            get
            {
                return PlanUnit.Unit?.Cost;
            }

            set
            {
                PlanUnit.Unit.Cost = value ?? 0;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        public int TotalCost
        {
            get
            {
                return 0;
            }
        }

        public string Link
        {
            get
            {
                return PlanUnit.Unit?.Link;
            }

            set
            {
                PlanUnit.Unit.Link = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<OptionViewModel> Options
        {
            get
            {
                return _options;
            }

            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        public OptionViewModel SelectedOption
        {
            get
            {
                return _selectedOption;
            }

            set
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }

        public void CreateNewOption()
        {
            var newOption = new OptionViewModel(new PlanOption());
            newOption.PropertyChanged += SelectedOption_PropertyChanged;

            Options.Add(newOption);

            SelectedOption = newOption;
        }

        internal void RemoveOption()
        {
            _options.Remove(SelectedOption);
            SelectedOption = null;

            OnPropertyChanged(nameof(Options));
            OnPropertyChanged(nameof(Cost));
            OnPropertyChanged(nameof(PointsValue));
        }

        private void SelectedOption_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedOption));
            OnPropertyChanged(nameof(Cost));
        }
    }
}