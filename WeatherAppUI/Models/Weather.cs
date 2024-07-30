using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Weather //To bo klicalo requests, dobilo data in vracalo podatke o vremenu
    {

        public Data Data{ get; private set; }
        public GoogleLocationData LocationData { get; private set; }
        public void MakeWeatherModel(Data data, GoogleLocationData locationData)
        {
            Data = data;
            LocationData = locationData;
        }

    }
}
