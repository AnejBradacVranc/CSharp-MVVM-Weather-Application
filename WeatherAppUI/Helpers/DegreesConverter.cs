using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Helpers
{
    public static class DegreesConverter
    {
        public static float[] ConvertToFahrenheit(float[] arr)
        {
            float[] result = new float[arr.Length];

            for(int i=0; i<arr.Length; i++)
            {
                result[i] = MathF.Round(arr[i] * 1.8f + 32.0f,1);
            }

            return result;
        }
    }
}
