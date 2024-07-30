using GeoTimeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TimeZoneConverter;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class RightSideWeatherDataViewModel
    {
        private readonly Data data;
        private readonly GoogleLocationData locationData;
        private float Windspeed => data.Current_weather.Windspeed;
        private string SpeedUnit => data.Hourly_units.Windspeed_10m.ToString();

        public string Winddirection => data.Current_weather.Winddirection + "°";      
        public float[] MaxTempsPerDay => data.Daily.Temperature_2m_max;
        public float[] MinTempsPerDay => data.Daily.Temperature_2m_min;
        private int[] WeatherCodes => data.Daily.Weathercode;
        public float[] PrecipationPerDay => data.Daily.Precipitation_sum;
        public string[] WeekDays => data.Daily.GetDays();
        public string[] WeekDailyDates => data.Daily.GetDailyDates();
        public string PrecipationUnit => data.Daily_units.Precipitation_sum.ToString();
        public string WindspeedData
        {
            get { return Windspeed.ToString() + SpeedUnit; }
        }
        public string Sunrise
        {
            get
            {               
                return Helpers.TimeConverter.convertTime(locationData,data,"sunrise");
            }
        }
        public string Sunset
        {
            get
            {

                return Helpers.TimeConverter.convertTime(locationData, data, "sunset");

            }
        }
        public string CurrentHumidity => data.Hourly.GetCurrentHumidity().ToString();
        public string UVIndex => data.Daily.GetDailyUVIndex();
        public string UVIndexClearSky => data.Daily.GetDailyClearSkyUVIndex();
        public string WarningImagePath { get { if (float.Parse(UVIndexClearSky) > 5.0f) return "/Images/warning.png"; else return "/Images/check-circle.png"; } }
        public int CurrentHumidityValue => data.Hourly.GetCurrentHumidity();
        public ImageSource[] CurrentWeatherImages => Helpers.WeatherStateToImagePath.GetImagePathArray(WeatherCodes);
               

        public RightSideWeatherDataViewModel(Data data, GoogleLocationData locationData)
        {
            this.data = data;
            this.locationData= locationData;
        }
    }
}
