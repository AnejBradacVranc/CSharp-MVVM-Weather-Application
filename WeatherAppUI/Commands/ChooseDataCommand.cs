using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Stores;
using WeatherApp.ViewModels;

namespace WeatherApp.Commands
{
    internal class ChooseDataCommand : CommandBase
    {
        private readonly ChooseLocationViewModel chooseLocationViewModel;
        private readonly NavigationStore navigationStore;


        public ChooseDataCommand(ChooseLocationViewModel chooseLocationVM,NavigationStore navigationStore)
        {            
            chooseLocationViewModel = chooseLocationVM;
            this.navigationStore = navigationStore;

        }

        public override void Execute(object? parameter)
        {
            MyURL url = new MyURL();
            url.SetURLBasedOnLocation(chooseLocationViewModel.Location);

            WeatherRequest weatherRequest = new WeatherRequest();
            weatherRequest.MakeRequest(url.UrlString);

            LocationRequest locationRequest = new LocationRequest();

            locationRequest.MakeRequest(chooseLocationViewModel.Location);//Check ce request uspe          

            Weather weatherModel = new Weather();
            weatherModel.MakeWeatherModel(weatherRequest.Data, locationRequest.LocationData);
            
            navigationStore.CurrentviewModel = new ViewWeatherViewModel(weatherModel);


          
        }
    }
}
