using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for DayCard.xaml
    /// </summary>
    public partial class DayCard : UserControl
    {
      
        public static readonly DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty MaxTempProperty = DependencyProperty.Register("MaxTemp", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty MinTempProperty = DependencyProperty.Register("MinTemp", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(DayCard));
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty PrecipationProperty = DependencyProperty.Register("Precipation", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty TempUnitProperty = DependencyProperty.Register("TempUnit", typeof(string), typeof(DayCard));
        public static readonly DependencyProperty PrecipationUnitProperty = DependencyProperty.Register("PrecipationUnit", typeof(string), typeof(DayCard));
        public string Day
        {
            get { return (string)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        public string PrecipationUnit
        {
            get { return (string)GetValue(PrecipationUnitProperty); }
            set { SetValue(PrecipationUnitProperty, value); }
        }

        public string TempUnit
        {
            get { return (string)GetValue(TempUnitProperty); }
            set { SetValue(TempUnitProperty, value); }
        }

        public string MaxTemp
        {
            get { return (string)GetValue(MaxTempProperty); }

            set { SetValue(MaxTempProperty, value); }
        }
        public string MinTemp
        {
            get { return (string)GetValue(MinTempProperty); }

            set { SetValue(MinTempProperty, value); }
        }

        public string Date
        {
            get { return (string)GetValue(DateProperty); }

            set { SetValue(DateProperty, value); }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }

            set { SetValue(SourceProperty, value); }
        }

        public string Precipation
        {
            get { return (string)GetValue(PrecipationProperty); }

            set { SetValue(PrecipationProperty, value); }
        }
        public DayCard()
        {
            InitializeComponent();
        }
    }
}
