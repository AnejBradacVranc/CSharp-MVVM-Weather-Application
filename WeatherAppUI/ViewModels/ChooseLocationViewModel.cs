using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Stores;
using WeatherApp.View;

namespace WeatherApp.ViewModels
{
    public class ChooseLocationViewModel : ViewModelBase
    {
        private string location;
        private PredictionsStore predictionsStore;

        public ObservableCollection<string> LocationPrediction => predictionsStore.PredictionsList;
                           
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));                   
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand KeyboardKeyUpCommand { get; set; }
        
        public ChooseLocationViewModel(Weather weather, NavigationStore navigationStore)
        {
            predictionsStore = new PredictionsStore();
            predictionsStore.PredictionsList = new ObservableCollection<string>();
            predictionsStore.PredictionsChanged += PredictionsStore_CollectionChanged;
           

            KeyboardKeyUpCommand = new KeyUpCommand(predictionsStore,this);                                                                    
            SubmitCommand = new ChooseDataCommand(this, navigationStore);
            predictionsStore.PredictionsList.Add("[Type wanted location]");
        }
        private void PredictionsStore_CollectionChanged()
        {                      
            OnPropertyChanged(nameof(LocationPrediction));        
        }   
 
    }
}
