using ArmyStarter.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArmyStarter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnCreateArmy_Click(object sender, RoutedEventArgs args)
        {
            ((MainPageViewModel)DataContext).CreateNewArmy();
        }

        private void OnCopyArmy_Click(object sender, RoutedEventArgs args)
        {
            ((MainPageViewModel)DataContext).CopyArmy();
        }

        private void OnRemoveArmy_Click(object sender, RoutedEventArgs args)
        {
            ((MainPageViewModel)DataContext).RemoveArmy();
        }

        private void RefreshArmies_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).RefreshProperties();
        }

        private void OnCreateArmyItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SelectedArmy.CreateNewArmyItem();
        }

        private void OnCopyArmyItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SelectedArmy.CopyArmyItem();
        }

        private void OnRemoveArmyItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SelectedArmy.RemoveArmyItem();
        }

        private void LaunchLink_Click(object sender, RoutedEventArgs e)
        {
            var link = ((MainPageViewModel)DataContext).SelectedArmy?.SelectedArmyUnit?.Link;
            if (!string.IsNullOrEmpty(link))
            {
                Windows.System.Launcher.LaunchUriAsync(new Uri(link));
            }
        }

        private void SaveArmies_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SaveArmies();
        }

        private void OnCreateOption_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SelectedArmy.SelectedArmyUnit.CreateNewOption();
        }

        private void OnRemoveOption_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).SelectedArmy.SelectedArmyUnit.RemoveOption();
        }

        private void OnArmyLink_Click(object sender, RoutedEventArgs e)
        {
            var link = ((PlanUnitViewModel)((Button)sender).DataContext)?.Link;
            if (!string.IsNullOrEmpty(link))
            {
                Windows.System.Launcher.LaunchUriAsync(new Uri(link));
            }
        }
    }
}
