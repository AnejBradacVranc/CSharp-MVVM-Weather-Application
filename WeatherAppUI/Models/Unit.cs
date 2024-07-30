using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Unit
    {
        public string WantedUnit { get; set; }
        public float TemperatureToday { get; set; }
        public float[] MaxDailyTemps { get; set; }
        public float[] MinDailyTemps { get; set; }

        public Unit(string wantedUnit, float temp, float[] max, float[] min)
        {
            WantedUnit = wantedUnit;
            TemperatureToday = temp;
            MaxDailyTemps = max;
            MinDailyTemps = min;
        }
    }      
}
