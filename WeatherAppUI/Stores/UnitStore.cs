using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Stores
{
    public class UnitStore
    {
        private Unit unit;

        public Unit Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnUnitChanged();
            }
        }

        private void OnUnitChanged()
        {
            CurrentUnitChanged?.Invoke();
        }

        public event Action CurrentUnitChanged;
    }
}
