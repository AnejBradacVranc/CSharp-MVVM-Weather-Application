using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Stores;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModels
{
    public class ViewWeatherViewModel : ViewModelBase
    {
        private readonly LeftSideWeatherDataViewModel leftSideWeatherDataViewModel;
        private readonly RightSideWeatherDataViewModel rightSideWeatherDataViewModel;
        private readonly UnitStore unitStore;

        public LeftSideWeatherDataViewModel LeftSideData => leftSideWeatherDataViewModel; //To zato da xaml lahko dostopa do tega
        public RightSideWeatherDataViewModel RightSideData => rightSideWeatherDataViewModel;

        public float TemperatureToday => unitStore.Unit.TemperatureToday;
        public float[] MaxDailyTemps => unitStore.Unit.MaxDailyTemps;
        public float[] MinDailyTemps => unitStore.Unit.MinDailyTemps;
        public string SelectedUnit => unitStore.Unit.WantedUnit;
        public ICommand ChooseTemperatureCelciusCommand { get; }
        public ICommand ChooseTemperatureFahrenheitCommand { get; }

        public ViewWeatherViewModel(Weather weather)
        {    
            leftSideWeatherDataViewModel = new LeftSideWeatherDataViewModel(weather.Data, weather.LocationData);
            rightSideWeatherDataViewModel = new RightSideWeatherDataViewModel(weather.Data, weather.LocationData);

            unitStore = new UnitStore();
            unitStore.Unit = new Unit("°C", weather.Data.Current_weather.Temperature, weather.Data.Daily.Temperature_2m_max, weather.Data.Daily.Temperature_2m_min);

            ChooseTemperatureCelciusCommand = new ChooseCelciusUnitCommand(this, unitStore);
            ChooseTemperatureFahrenheitCommand = new ChooseFahrenheitUnitCommand(this, unitStore);

            unitStore.CurrentUnitChanged += UnitStore_CurrentUnitChanged;

        }

        private void UnitStore_CurrentUnitChanged()
        {
            OnPropertyChanged(nameof(SelectedUnit));
            OnPropertyChanged(nameof(TemperatureToday));
            OnPropertyChanged(nameof(MaxDailyTemps));
            OnPropertyChanged(nameof(MinDailyTemps));
        }
    }
}
