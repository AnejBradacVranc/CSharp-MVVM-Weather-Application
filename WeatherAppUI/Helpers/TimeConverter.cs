using GeoTimeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;
using WeatherApp.Models;

namespace WeatherApp.Helpers
{
    public static class TimeConverter
    {
        public static string convertTime(GoogleLocationData locationData, Data data, string flag)
        {
            float lat = locationData.results[0].geometry.location.lat;
            float lng = locationData.results[0].geometry.location.lng;
            string tz = TimeZoneLookup.GetTimeZone(lat, lng).Result;

            TimeZoneInfo tzInfo = TZConvert.GetTimeZoneInfo(tz);


            if (flag == "sunrise")
                return TimeZoneInfo.ConvertTime(DateTime.Parse(data.Daily.Sunrise[0]), tzInfo).ToString("t");
            else if (flag == "sunset")
                return TimeZoneInfo.ConvertTime(DateTime.Parse(data.Daily.Sunset[0]), tzInfo).ToString("t");
            else if (flag == "currentShort")
                return TimeZoneInfo.ConvertTime(DateTimeOffset.Now, tzInfo).ToString("t");
            else if (flag == "currentLong")
                return TimeZoneInfo.ConvertTime(DateTimeOffset.Now, tzInfo).ToString("ddd") + " " + TimeZoneInfo.ConvertTime(DateTimeOffset.Now, tzInfo).ToString("t");
            else return
                    String.Empty;

        }
    }
}
