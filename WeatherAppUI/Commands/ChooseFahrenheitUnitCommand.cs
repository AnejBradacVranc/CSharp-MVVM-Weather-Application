using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Stores;
using WeatherApp.ViewModels;
using WeatherApp.Models;

namespace WeatherApp.Commands
{
    public class ChooseFahrenheitUnitCommand :CommandBase
    {
        private readonly ViewWeatherViewModel viewWeatherViewModel;
        private readonly UnitStore unitStore;

        public ChooseFahrenheitUnitCommand(ViewWeatherViewModel viewWeatherVM, UnitStore unitStore)
        {
            viewWeatherViewModel = viewWeatherVM;
            this.unitStore = unitStore;
        }

        public override void Execute(object? parameter)
        {
            LeftSideWeatherDataViewModel leftSide = viewWeatherViewModel.LeftSideData;
            RightSideWeatherDataViewModel rightSide = viewWeatherViewModel.RightSideData;

            unitStore.Unit = new Unit(
                "°F", MathF.Round(leftSide.Temperature * 1.8f + 32, 1), 
                Helpers.DegreesConverter.ConvertToFahrenheit(rightSide.MaxTempsPerDay), 
                Helpers.DegreesConverter.ConvertToFahrenheit(rightSide.MinTempsPerDay)
                );

        }
    }
}
