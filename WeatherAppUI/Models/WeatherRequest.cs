using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Media.Animation;
using GoogleMaps.LocationServices;

namespace WeatherApp.Models
{
    public class WeatherRequest //To bo handlalo requests. Poslalo željen request, pridobilo podatke in jih vrnilo
    {
      
        public Data ?Data { get; private set; }


        public void MakeRequest(string url)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                Data dataObj = response.Content.ReadAsAsync<Data>().Result;
                Data = dataObj;
                
            }
        }
       

    }
}
