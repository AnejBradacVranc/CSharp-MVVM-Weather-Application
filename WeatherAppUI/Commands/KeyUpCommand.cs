using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Stores;
using WeatherApp.View;
using WeatherApp.ViewModels;

namespace WeatherApp.Commands
{
    public class KeyUpCommand :CommandBase
    {
        private readonly PredictionsStore predictionsStore;
        private readonly ChooseLocationViewModel chooseLocationViewModel;
        static LocationRequest locationRequest;


        
        public KeyUpCommand( PredictionsStore predStore, ChooseLocationViewModel chooseLocationVM)
        {
            predictionsStore= predStore;
            chooseLocationViewModel = chooseLocationVM;
            locationRequest = new LocationRequest();
        }
  
        public override void Execute(object? parameter)
        {
           
            ChooseLocationViewModel sender = parameter as ChooseLocationViewModel;  
            
            if (!(sender.Location != null && predictionsStore.PredictionsList.Count == 0))
            {
                
                locationRequest.MakePredictionRequest(sender.Location);

                if (locationRequest.LocationPrediction != null)
                {
                    LocationPredictions.Prediction[] arr = locationRequest.LocationPrediction.Predictions;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!predictionsStore.PredictionsList.Contains(arr[i].description))
                            predictionsStore.PredictionsList.Add(arr[i].description);
                    }



                }                

            }
        }
    }
}
