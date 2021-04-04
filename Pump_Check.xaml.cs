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

namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for Pump_Check.xaml
    /// </summary>
    public partial class Pump_Check : Page
    {
        public Pump_Check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            //P1
            true_p1.Opacity = 0.15;
            false_p1.Opacity = 0.15;

            //P2
            true_p2.Opacity = 0.15;
            false_p2.Opacity = 0.15;

            //P3
            true_p3.Opacity = 0.15;
            false_p3.Opacity = 0.15;

            //P4
            true_p4.Opacity = 0.15;
            false_p4.Opacity = 0.15;

            //P5
            true_p5.Opacity = 0.15;
            false_p5.Opacity = 0.15;

            //P6
            true_p6.Opacity = 0.15;
            false_p6.Opacity = 0.15;

            //P7
            true_7.Opacity = 0.15;
            false_p7.Opacity = 0.15;

            //P8
            true_p8.Opacity = 0.15;
            false_p8.Opacity = 0.15;

            //P9
            true_p9.Opacity = 0.15;
            false_p9.Opacity = 0.15;

            //P10
            true_p10.Opacity = 0.15;
            false_p10.Opacity = 0.15;

            //P11
            true_p11.Opacity = 0.15;
            false_p11.Opacity = 0.15;

            //P12
            true_p12.Opacity = 0.15;
            false_12.Opacity = 0.15;

            //P13
            true_p13.Opacity = 0.15;
            false_p13.Opacity = 0.15;

            //P14
            true_p14.Opacity = 0.15;
            false_p14.Opacity = 0.15;

            //P15
            true_p15.Opacity = 0.15;
            false_15.Opacity = 0.15;

            //P16
            true_16.Opacity = 0.15;
            false_p16.Opacity = 0.15;
        }

        /*
       p1
       */

        private void true_p1btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p1btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
         p2
         */
        private void true_p2btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p2btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p3
        */

        private void true_p3btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p3btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p4
        */

        private void true_p4btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p4btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
       p5
       */

        private void true_p5btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p5btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p6
        */

        private void true_p6btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p6btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p7
        */

        private void true_p7btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p7btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p8
        */

        private void true_p8btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p8btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p9
        */

        private void true_p9btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p9btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p10
        */

        private void true_p10btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p10btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p11
        */

        private void true_p11btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p11btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p12
        */

        private void true_p12btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p12btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p13
        */

        private void true_p13btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p13btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p14
        */

        private void true_p14btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p14btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
        p15
        */

        private void true_p15btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p15btn(object sender, MouseButtonEventArgs e)
        {

        }

        /*
       p16
        */

        private void true_16btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void false_p16btn(object sender, MouseButtonEventArgs e)
        {

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Goback_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.vehicle());
        }
    }
}
