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
using Lafarge_WPF.Pages;

namespace Lafarge_WPF.Pages

{
    /// <summary>
    /// Interaction logic for weekly_report.xaml
    /// </summary>
    public partial class weekly_report : Page
    {
        public weekly_report()
        {
            InitializeComponent();
        }

        private void weekly_report_Selection(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Goback_btn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.view_report());
        }

        private void Download_btn(object sender, RoutedEventArgs e)
        {

        }
    }
}
