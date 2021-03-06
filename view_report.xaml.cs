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
    /// Interaction logic for view_report.xaml
    /// </summary>
    public partial class view_report : Page
    {
        public view_report()
        {
            InitializeComponent();
        }

        private void Weekly_report(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.weekly_report());
        }

        private void Monthly_report(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Monthly_report());
        }
    }
}
