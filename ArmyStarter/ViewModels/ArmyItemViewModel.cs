using ArmyStarter.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class ArmyUnitViewModel : ViewModelBase
    {
        private OptionViewModel _selectedOption;
        private ObservableCollection<OptionViewModel> _options;

        public ArmyUnitViewModel(ArmyUnit armyItem)
        {
            ArmyUnit = armyItem;
            if (armyItem.Options == null)
            {
                Options = new ObservableCollection<OptionViewModel>();
            }
            else
            {
                Options = new ObservableCollection<OptionViewModel>(armyItem.Options.Select(option => new OptionViewModel(option)));
            }
        }

        public ArmyUnit ArmyUnit { get; set; }

        public string Name
        {
            get
            {
                return ArmyUnit.Name;
            }

            set
            {
                ArmyUnit.Name = value;
                OnPropertyChanged();
            }
        }

        public int PointsValue
        {
            get
            {
                return ArmyUnit.PointsValue;
            }

            set
            {
                ArmyUnit.PointsValue = value;
                OnPropertyChanged();
            }
        }

        public int Cost
        {
            get
            {
                return ArmyUnit.Cost;
            }

            set
            {
                ArmyUnit.Cost = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        public int TotalCost
        {
            get
            {
                return ArmyUnit.TotalCost;
            }
        }

        public string Link
        {
            get
            {
                return ArmyUnit.Link;
            }

            set
            {
                ArmyUnit.Link = value;
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
            var newOption = new OptionViewModel(new Option());
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