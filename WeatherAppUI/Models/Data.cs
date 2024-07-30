using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WeatherApp.Models
{

    public class Data
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Generationtime_ms { get; set; }
        public int Utc_offset_seconds { get; set; }
        public string Timezone { get; set; }
        public string Timezone_abbreviation { get; set; }
        public float Elevation { get; set; }
        public Current_Weather Current_weather { get; set; }
        public Hourly_Units Hourly_units { get; set; }
        public Hourly Hourly { get; set; }
        public Daily_Units Daily_units { get; set; }
        public Daily Daily { get; set; }
    }

    public class Current_Weather
    {
        public float Temperature { get; set; }
        public float Windspeed { get; set; }
        public float Winddirection { get; set; }
        public int Weathercode { get; set; }
        public string Time { get; set; }
    }

    public class Hourly_Units
    {
        public string Time { get; set; }
        public string Temperature_2m { get; set; }
        public string Relativehumidity_2m { get; set; }
        public string Apparent_temperature { get; set; }
        public string Precipitation { get; set; }
        public string Windspeed_10m { get; set; }
    }

    public class Hourly
    {
        public string[] Time { get; set; }
        public float[] Temperature_2m { get; set; }
        public int[] Relativehumidity_2m { get; set; }
        public float[] Apparent_temperature { get; set; }
        public float[] Precipitation { get; set; }
        public float[] Windspeed_10m { get; set; }
        public int GetCurrentHumidity()
        {
            var dict = new System.Collections.Generic.Dictionary<string, int>();
            int value = 0;

            for(int i=0; i<Time.Length; i++)
                dict.Add(Time[i].Substring(0,13), Relativehumidity_2m[i]);


            string dt = DateTime.Now.ToString("s").Substring(0,13);
            
            if (dict.TryGetValue(dt,out value))
                return value;
            else
                return 0;

        }
    }

    public class Daily_Units
    {
        public string Time { get; set; }
        public string Weathercode { get; set; }
        public string Temperature_2m_max { get; set; }
        public string Temperature_2m_min { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Precipitation_sum { get; set; }
        public string Precipitation_probability_max { get; set; }
               
    }

    public class Daily
    {
        public string[] Time { get; set; }
        public int[] Weathercode { get; set; }
        public float[] Temperature_2m_max { get; set; }
        public float[] Temperature_2m_min { get; set; }
        public string[] Sunrise { get; set; }
        public string[] Sunset { get; set; }
        public float[] Precipitation_sum { get; set; }
        public int[] Precipitation_probability_max { get; set; }
        public float[] Uv_index_max { get; set; }
        public float[] Uv_index_clear_sky_max { get; set; }

        public string GetSunriseHour()
        {
            string dt = DateTime.Parse(Sunrise[0]).ToString("t");
            return dt;
        }
        public string GetSunsetHour()
        {
            string dt = DateTime.Parse(Sunset[0]).ToString("t");
            return dt;
        }
        public string GetMaxProbability()
        {
            return Precipitation_probability_max.Max().ToString();
        }
        public string[] GetDays()
        {
            string[] fullDates= new string[Time.Length];

            for(int i=0; i<Time.Length;i++)
            {
                fullDates[i] = DateTime.Parse(Time[i]).ToString("ddd");
            }
            return fullDates;
        }
        public string[] GetDailyDates()
        {
            string[] fullDates = new string[Time.Length];

            for (int i = 0; i < Time.Length; i++)
            {
                fullDates[i] = DateTime.Parse(Time[i]).ToString("M");
            }
            return fullDates;
        }
        public string GetDailyUVIndex()
        {
            return Math.Round(Uv_index_max.Average(),2).ToString(); 

        }
        public string GetDailyClearSkyUVIndex()
        {
            return Math.Round(Uv_index_clear_sky_max.Average(),2).ToString();

        }

              
    }

}
