using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.Models;
using WeatherApp.Stores;
using WeatherApp.View;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///    
    public partial class App : Application
    {
        private readonly Weather weather;
        private readonly NavigationStore navigationStore;

        public App()
        {
            weather = new Weather();
            navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
                        
            navigationStore.CurrentviewModel = new ChooseLocationViewModel(weather, navigationStore);
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)               
            };
            MainWindow.Show();
                        
            base.OnStartup(e);
        }
    }
}
