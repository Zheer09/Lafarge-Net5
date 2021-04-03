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

namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for vehicle.xaml
    /// </summary>
    public partial class vehicle : Page
    {
        public vehicle()
        {
            InitializeComponent();
        }

        private void Loader_Checked(object sender, RoutedEventArgs e)
        {
            if (GlobalClass.CheckForInternetConnection())
            {
                this.NavigationService.Navigate(new Loader_check());
            }
            else
            {
                MessageBox.Show("Warning: you are not connected to internet!");
            }
            
        }


        private void Pump_Checked(object sender, RoutedEventArgs e)
        {
            
            if (GlobalClass.CheckForInternetConnection())
            {
                this.NavigationService.Navigate(new Pump_Check());
            }
            else
            {
                MessageBox.Show("Warning: you are not connected to internet!");
            }
        }

        private void Mixer_Checked(object sender, RoutedEventArgs e)
        {
            
            if (GlobalClass.CheckForInternetConnection())
            {
                this.NavigationService.Navigate(new Mixer_check());
            }
            else
            {
                MessageBox.Show("Warning: you are not connected to internet!");
            }
        }
    }
}
