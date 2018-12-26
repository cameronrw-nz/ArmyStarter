using ArmyStarter.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArmyStarter.ViewModels
{
    public class ArmyItemViewModel : ViewModelBase
    {
        private OptionViewModel _selectedOption;

        public ArmyItemViewModel(ArmyItem armyItem)
        {
            ArmyItem = armyItem;
            Options = new ObservableCollection<OptionViewModel>(armyItem.Options.Select(option => new OptionViewModel(option)));
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
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        public int TotalCost
        {
            get
            {
                return Cost + Options.Sum(option => option.Cost);
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

        public ObservableCollection<OptionViewModel> Options { get; set; }

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

        private void SelectedOption_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedOption));
            OnPropertyChanged(nameof(Cost));
        }
    }
}