using GeoTimeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace WeatherApp.Models
{
    public class MyURL
    {

        public string UrlString { get; private set; }


        public void SetURLBasedOnLocation(string address)
        {
            string leftHalf = "http://api.open-meteo.com/v1/forecast?";
            string rightHalf = "&current_weather=true&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,windspeed_10m&daily=weathercode,uv_index_max,uv_index_clear_sky_max,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,precipitation_probability_max&timezone=Europe%2FBerlin";
            string middle = "";
            string url = "";

            LocationRequest locationRequest = new LocationRequest();
            locationRequest.MakeRequest(address);

            string lat = locationRequest.LocationData.results[0].geometry.location.lat.ToString().Replace(',', '.');
            string lng = locationRequest.LocationData.results[0].geometry.location.lng.ToString().Replace(',', '.');



            middle = "latitude=" + lat + "&" + "longitude=" + lng;
            url = leftHalf + middle + rightHalf;
            UrlString = url;
        }
    }
}
