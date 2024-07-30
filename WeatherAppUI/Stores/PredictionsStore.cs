using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Stores
{
    public class PredictionsStore
    {
            
          private ObservableCollection<string> predictionsList;
        
          public ObservableCollection<string> PredictionsList
            {
            get => predictionsList;

             set
             {               
                this.predictionsList = value;
                this.predictionsList.CollectionChanged += PredictionsList_CollectionChanged;
            }
          }

        private void PredictionsList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
            predictionsList.CollectionChanged -= PredictionsList_CollectionChanged;

            if (e.NewItems != null)
                PredictionsChanged?.Invoke();            

        }

        public event Action PredictionsChanged;
    }
}
