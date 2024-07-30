using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels;

namespace WeatherApp.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _CurrentviewModel;
        public ViewModelBase CurrentviewModel
        {
            get => _CurrentviewModel;
            set
            {
                _CurrentviewModel = value;
                OnCurrentViewModelChanged(); //Ko settas current view model naredis se event ki spremeni pogled oken
            }

        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}
