using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged; //Event, ki pove UI katere bindings updejtat

        protected void OnPropertyChanged(string propertyName) //Samo inherited class lahko klice
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //Ce karkoli ma event PropertyChanged. To metodo klicemo da povemo UI kdaj se property spremeni da views lahko vzamejo propery value in posodobijo UI
        }
    }
}
