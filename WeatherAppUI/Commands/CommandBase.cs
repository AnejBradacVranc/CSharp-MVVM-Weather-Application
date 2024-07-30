using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.Commands
{
    public abstract class CommandBase : ICommand //UI bo sel se not uporabljal metode in poslusal CanExecuteChanged
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter) //Pove ce se comanda lahko izvede. Ce bo false, ne gre kiknit gumba
        {
            return true;
        }

        public abstract void Execute(object? parameter); //Vse kar bo tu not se bo izvedlo
        protected void OnExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
       
    }
}
