using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.View;
using WeatherApp.Models;
using WeatherApp.Stores;

namespace WeatherApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase //Priakzuje trenutni viewModel aplikacije
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentviewModel; //Ta se sicer spremeni ampak je potreben event da UI regrabba. View ni regrabbal CurrentViewModel - glej MainWindow.xaml
        //navigationStore opozori MainViewModel, kdaj se CurrentViewModel spremeni
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;

            navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged; //Ko se CurrentviewModel Spremeni! Tukaj se samo Subscribamo na ta event, se vpisemo v njega
        }

        private void NavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel)); //UI spremenimo property za CurrentviewModel in ga regrabba
        }

     
    }
}
