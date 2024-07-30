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
using WeatherApp.Models;
using WeatherApp.Stores;
using WeatherApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for ChooseLocationView.xaml
    /// </summary>
    public partial class ChooseLocationView : UserControl
    {
        public ChooseLocationView()
        {                       
            InitializeComponent();
            
        }
       
        private void Cmb_KeyUp(object sender, KeyEventArgs e)
        {           
            

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(Cmb.ItemsSource);

            if (collectionView.Count == 0)
            {
                Cmb.IsDropDownOpen = false;

            }
            else if (collectionView != null)
            {
                Cmb.IsDropDownOpen = true;
            }


            collectionView.Filter = ((o) =>
                {
                    if (String.IsNullOrEmpty(Cmb.Text)) return true;
                    else
                    {
                        if (((string)o).Contains(Cmb.Text)) return true;
                        else return false;
                    }
                });

                collectionView.Refresh();
        
            }                          
                
    }
}
