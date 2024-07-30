using GeoTimeZone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TimeZoneConverter;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class LeftSideWeatherDataViewModel : ViewModelBase
    {
        private readonly Data data;
        private readonly GoogleLocationData location;
        private string Time => data.Current_weather.Time.ToString();
        private string OnlyTime
        {
            get
            {
                return Helpers.TimeConverter.convertTime(location, data, "currentShort");
            }
        }

        public string Sunrise
        {
            get
            {
                return Helpers.TimeConverter.convertTime(location, data, "sunrise");
            }
        }
        public string Sunset
        {
            get
            {
                return Helpers.TimeConverter.convertTime(location, data, "sunset");

            }
        }
        public int WeatherCode => data.Current_weather.Weathercode;
        public float Temperature => data.Current_weather.Temperature;
        public string WeatherCaptureTime
        {
            get
            {

                var cultureInfo = new CultureInfo("sl-SI");
                DateTime dateTime = DateTime.Parse(Time, cultureInfo, DateTimeStyles.NoCurrentDateDefault);
                return dateTime.ToString("dddd") + " " + dateTime.ToString("t");
            }
        }
        public string CurrentTime
        {
            get {                        
                return Helpers.TimeConverter.convertTime(location, data, "currentLong");
            }
        }        
        public string FullLocationName => location.results[0].formatted_address;
        public string PrecipationProbability => data.Daily.GetMaxProbability();
        public Address_Components[] Address_Components => location.results[0].address_components;       
        public string ShortLocationName { 
            get
            {//POPRAVI!

                List<string> locationData = new List<string>();
                foreach (var address in Address_Components)
                    if (address.types[0] == "postal_town" || address.types[0] == "country")
                        locationData.Add(address.long_name);

                string locationName = "";

                if (locationData.Count > 1)
                    locationName = locationData[0] + "," + locationData[1];
                else
                    locationName = locationData[0];

                return locationName;
            }
        
        }        
        public string PhotoPath{
            get
            {
                LocationRequest lr = new LocationRequest();
                lr.MakeRequest(ShortLocationName);
                string imagePathString = lr.GetImagePath(lr.LocationData.results[0].place_id);
                return imagePathString;

            }
        }             
        public ImageSource WeatherPhotoPath
        {
            get {

                DateTime sunsetTime = DateTime.Parse(Sunset);
                DateTime sunriseTime = DateTime.Parse(Sunrise);
                DateTime now = DateTime.Parse(OnlyTime);

                if (now > sunriseTime && now < sunsetTime)
                    return Helpers.WeatherStateToImagePath.GetImagePath(WeatherCode);
                else
                    return Helpers.WeatherStateToImagePath.GetImagePathNight(WeatherCode);

            }
        }

        public LeftSideWeatherDataViewModel(Data data, GoogleLocationData locationData)
        {
            this.data= data;
            location= locationData;
        }
    }
}
