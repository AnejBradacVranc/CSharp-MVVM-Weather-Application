using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using WeatherApp.Models;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using Newtonsoft.Json.Bson;
using System.Windows.Controls;

namespace WeatherApp.Models
{
    public class LocationRequest  //To bo uporabljeno ko bo uporabnik izbral kaksno drugo lokacijo bo v linku spremenilo longitude in latitude iz address
    {
       
        public GoogleLocationData?  LocationData { get; private set; }
        private GooglePlaceImageData.PlaceImageData? PlaceImageData { get; set; }
        public LocationPredictions.LocationPredictionData? LocationPrediction { get; set; }

        private  readonly   string APIKEY_LOCATION = Properties.Settings.Default.APIKEY_LOCATION;
        private  readonly  string APIKEY_IMAGES = Properties.Settings.Default.APIKEY_IMAGES;


        public void MakeRequest(string address)
        {
            
            string baseString = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url = baseString + address + "&key="+ APIKEY_LOCATION; //Api poskrbri da je lahko noter marsikaj

            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;
      

            if (response.IsSuccessStatusCode)
            {
                GoogleLocationData data = response.Content.ReadAsAsync<GoogleLocationData>().Result;
                LocationData = data;
            }
        }

        private void MakeImageRequest(string place_id)
        {            
            string baseString = "https://maps.googleapis.com/maps/api/place/details/json?place_id=";
            string type = "&fields=photo&key=";
            string url = baseString + place_id + type + APIKEY_IMAGES;            

            using HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                GooglePlaceImageData.PlaceImageData data = response.Content.ReadAsAsync<GooglePlaceImageData.PlaceImageData>().Result;
                PlaceImageData = data;
            }
        }

        public void MakePredictionRequest(string value)
        {
            if (value != null)
            {
                string baseUrl = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
                string parameters = "&types=(cities)&key=";
                string url = baseUrl + value + parameters + APIKEY_IMAGES;

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Task<HttpResponseMessage> response = client.GetAsync(url);

                if (response.Result.IsSuccessStatusCode)
                {
                    LocationPredictions.LocationPredictionData data = response.Result.Content.ReadAsAsync<LocationPredictions.LocationPredictionData>().Result;
                    LocationPrediction = data;
                }
            }
        }

        public string GetImagePath(string place_id)
        {
            MakeImageRequest(place_id);

            Random rnd = new Random();
          
            string photoReference = PlaceImageData.result.photos[rnd.Next(0, PlaceImageData.result.photos.Length - 1)].photo_reference;
            string baseUrl = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=";            
            string url = baseUrl + photoReference + "&key=" + APIKEY_IMAGES;


            return url;
        }


    }
}
