using ArmyStarter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Windows.Storage;

namespace ArmyStarter.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<ArmyViewModel> _armies;
        private ArmyViewModel _selectedArmy;

        public MainPageViewModel()
        {
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

        public void RefreshProperties()
        {
            OnPropertyChanged(nameof(SelectedArmy));
            OnPropertyChanged(nameof(Armies));
        }

        private async void InitiliseMainPage()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Army>));

            StorageFile file = (StorageFile)await ApplicationData.Current.LocalFolder.TryGetItemAsync("settings.xml");
            if (file != null)
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    using (TextReader tr = new StreamReader(stream))
                    {
                        var armies = (List<Army>)xs.Deserialize(tr);
                        foreach (Army army in armies)
                        {
                            Armies.Add(new ArmyViewModel(army));
                        }
                    }
                }
            }
            else
            {
                var army = new Army { Name = "Default Army" };
                var defaultArmy = new ArmyViewModel(army);
                Armies = new ObservableCollection<ArmyViewModel> { defaultArmy };
            }
        }

        public async void SaveArmiesToFile()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Army>));
            
            StorageFile file = (StorageFile) await ApplicationData.Current.LocalFolder.TryGetItemAsync("settings.xml");
            if (file == null)
            {
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("settings.xml");
            }

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                using (TextWriter tw = new StreamWriter(stream))
                {
                    var armies = new List<Army>();
                    foreach (ArmyViewModel armyVM in Armies)
                    {
                        var army = armyVM.Army;
                        army.HQs = armyVM.ArmyItems.Select(armyItem => armyItem.ArmyItem).ToList();
                        armies.Add(army);
                    }
                    xs.Serialize(tw, armies);
                }
            }
        }
    }
}
