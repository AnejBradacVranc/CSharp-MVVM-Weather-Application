using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeatherApp.Helpers
{
    public static class WeatherStateToImagePath
    {
        private static string projectDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));

        private static string path = Path.GetFullPath(Path.Combine(projectDir, "Images"));

        private static Dictionary<int, string> codeValuepairsDay = new Dictionary<int, string>
        {
            {0, "sunshine.png"},
            {1, "sun-cloud.png"},
            {2, "sun-cloud.png"},
            {3, "clouds (1).png"},
            {45, "fog.png"},
            {48, "fog.png"},
            {51, "fog.png"},
            {53, "fog.png"},
            {55, "fog.png"},
            {56, "fog.png"},
            {57, "fog.png"},
            {61, "rainy-day.png"},
            {63, "rainy-day.png"},
            {65, "heavy-rain.png"},
            {66, "snows.png"},
            {67, "snows.png"},
            {71, "snows.png"},
            {73, "snows.png"},
            {75, "snows.png"},
            {77, "snows.png"},
            {80, "rainy-day.png"},
            {81, "heavy-rain.png"},
            {82, "heavy-rain (1).png"},
            {85, "snows.png"},
            {86, "snow-storm.png"},
            {95, "thunderstorm.png"},
            {96, "snow-storm.png"},
            {99, "snow-storm.png"}
        };

        private static Dictionary<int, string> codeValuepairsNight = new Dictionary<int, string>
        {
            {0, "night.png"},
            {1, "cloudy-night.png"},
            {2, "cloudy-night.png"},
            {3, "clouds (1).png"},
            {45, "fog.png"},
            {48, "fog.png"},
            {51, "fog.png"},
            {53, "fog.png"},
            {55, "fog.png"},
            {56, "fog.png"},
            {57, "fog.png"},
            {61, "rainy-night.png"},
            {63, "rainy-night.png"},
            {65, "heavy-rain.png"},
            {66, "snows.png"},
            {67, "snows.png"},
            {71, "snows.png"},
            {73, "snows.png"},
            {75, "snows.png"},
            {77, "snows.png"},
            {80, "rainy-day.png"},
            {81, "heavy-rain.png"},
            {82, "heavy-rain (1).png"},
            {85, "snows.png"},
            {86, "snow-cloud.png"},
            {95, "thunderstorm (4).png"},
            {96, "snow-cloud.png"},
            {99, "snow-cloud.png"}
        };

        public static ImageSource GetImagePath(int weathercode)
        {
            var converter = new ImageSourceConverter();

            if (codeValuepairsDay.ContainsKey(weathercode)) {                                
                return (ImageSource)converter.ConvertFromString(Path.Combine(path , codeValuepairsDay[weathercode]));
              }
            else
                return (ImageSource)converter.ConvertFromString( Path.Combine(path ,"warning.png"));
        }

        public static ImageSource GetImagePathNight(int weathercode)
        {
            var converter = new ImageSourceConverter();

            if (codeValuepairsNight.ContainsKey(weathercode))
            {
                return (ImageSource)converter.ConvertFromString(Path.Combine(path ,codeValuepairsNight[weathercode]));
            }
            else
                return (ImageSource)converter.ConvertFromString(Path.Combine(path , "warning.png"));
        }

        public static ImageSource[] GetImagePathArray(int[] weathercodes)
        {
            ImageSource[] arr = new ImageSource[weathercodes.Length];
            int i = 0;

            foreach(int weathercode in weathercodes)
            {
                arr[i] = GetImagePath(weathercode);
                i++;
            }

            return arr;
        }
    }
}
