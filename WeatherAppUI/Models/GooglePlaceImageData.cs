using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class GooglePlaceImageData
    {
        public class PlaceImageData
        {
            public object[] html_attributions { get; set; }
            public Result result { get; set; }
            public string status { get; set; }
        }

        public class Result
        {
            public Photo[] photos { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public string[] html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

    }
}
