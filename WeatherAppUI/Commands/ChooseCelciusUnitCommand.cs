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
    class ChooseCelciusUnitCommand : CommandBase
    {
        private readonly ViewWeatherViewModel viewWeatherViewModel;
        UnitStore unitStore;

        public ChooseCelciusUnitCommand(ViewWeatherViewModel viewWeatherVM, UnitStore unitStore)
        {
            viewWeatherViewModel = viewWeatherVM;
            this.unitStore = unitStore;
        }

        public override void Execute(object? parameter)
        {
            LeftSideWeatherDataViewModel leftSide = viewWeatherViewModel.LeftSideData;
            RightSideWeatherDataViewModel rightSide = viewWeatherViewModel.RightSideData;
            unitStore.Unit = new Unit("°C", leftSide.Temperature, rightSide.MaxTempsPerDay, rightSide.MinTempsPerDay);

        }
    
    }
}
