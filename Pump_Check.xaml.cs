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
        bool[] pump_check = new bool[16];
        string[] loader_note = new string[16];
        string v_type = "Pump";
        double last_wh = 0, new_wh = 0;
        double wh_50 = 0;
        double wh_300 = 0;
        int num_of_index = 0;
        public Pump_Check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("yyyy-MM-dd HH:mm");

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

        private bool validateSubmit()
        {

            // code...


            return false;
        }


        /*
       p1
       */

        private void true_p1btn(object sender, MouseButtonEventArgs e)
        {
            false_p1.Opacity = 0.15;
            true_p1.Opacity = 1;
            pump_check[0] = true;
        }

        private void false_p1btn(object sender, MouseButtonEventArgs e)
        {
            false_p1.Opacity = 1;
            true_p1.Opacity = 0.15;
            pump_check[0] = false;
        }

        /*
         p2
         */
        private void true_p2btn(object sender, MouseButtonEventArgs e)
        {
            false_p2.Opacity = 0.15;
            true_p2.Opacity = 1;
            pump_check[1] = true;
        }

        private void false_p2btn(object sender, MouseButtonEventArgs e)
        {
            false_p2.Opacity = 1;
            true_p2.Opacity = 0.15;
            pump_check[1] = false;

        }

        /*
        p3
        */

        private void true_p3btn(object sender, MouseButtonEventArgs e)
        {

            false_p3.Opacity = 0.15;
            true_p3.Opacity = 1;
            pump_check[2] = true;

        }

        private void false_p3btn(object sender, MouseButtonEventArgs e)
        {
            false_p3.Opacity = 1;
            true_p3.Opacity = 0.15;
            pump_check[2] = false;
        }

        /*
        p4
        */

        private void true_p4btn(object sender, MouseButtonEventArgs e)
        {
            false_p4.Opacity = 0.15;
            true_p4.Opacity = 1;
            pump_check[3] = true;
        }

        private void false_p4btn(object sender, MouseButtonEventArgs e)
        {
            false_p4.Opacity = 1;
            true_p4.Opacity = 0.15;
            pump_check[3] = false;
        }

        /*
       p5
       */

        private void true_p5btn(object sender, MouseButtonEventArgs e)
        {
            false_p5.Opacity = 0.15;
            true_p5.Opacity = 1;
            pump_check[4] = true;
        }

        private void false_p5btn(object sender, MouseButtonEventArgs e)
        {
            false_p5.Opacity = 1;
            true_p5.Opacity = 0.15;
            pump_check[4] = false;
        }

        /*
            p6
        */

        private void true_p6btn(object sender, MouseButtonEventArgs e)
        {
            false_p6.Opacity = 0.15;
            true_p6.Opacity = 1;
            pump_check[5] = true;
        }

        private void false_p6btn(object sender, MouseButtonEventArgs e)
        {
            false_p6.Opacity = 1;
            true_p6.Opacity = 0.15;
            pump_check[5] = false;
        }

        /*
            p7
        */

        private void true_p7btn(object sender, MouseButtonEventArgs e)
        {
            false_p7.Opacity = 0.15;
            true_7.Opacity = 1;
            pump_check[6] = true;
        }

        private void false_p7btn(object sender, MouseButtonEventArgs e)
        {
            false_p7.Opacity = 1;
            true_7.Opacity = 0.15;
            pump_check[6] = false;
        }

        /*
        p8
        */

        private void true_p8btn(object sender, MouseButtonEventArgs e)
        {
            false_p8.Opacity = 0.15;
            true_p8.Opacity = 1;
            pump_check[7] = true;
        }

        private void false_p8btn(object sender, MouseButtonEventArgs e)
        {
            false_p8.Opacity = 1;
            true_p8.Opacity = 0.15;
            pump_check[7] = false;
        }

        /*
        p9
        */

        private void true_p9btn(object sender, MouseButtonEventArgs e)
        {
            false_p9.Opacity = 0.15;
            true_p9.Opacity = 1;
            pump_check[8] = true;
        }

        private void false_p9btn(object sender, MouseButtonEventArgs e)
        {
            false_p9.Opacity = 1;
            true_p9.Opacity = 0.15;
            pump_check[8] = false;
        }

        /*
        p10
        */

        private void true_p10btn(object sender, MouseButtonEventArgs e)
        {
            false_p10.Opacity = 0.15;
            true_p10.Opacity = 1;
            pump_check[9] = true;
        }

        private void false_p10btn(object sender, MouseButtonEventArgs e)
        {
            false_p10.Opacity = 1;
            true_p10.Opacity = 0.15;
            pump_check[9] = false;
        }

        /*
        p11
        */

        private void true_p11btn(object sender, MouseButtonEventArgs e)
        {
            false_p11.Opacity = 0.15;
            true_p11.Opacity = 1;
            pump_check[10] = true;
        }

        private void false_p11btn(object sender, MouseButtonEventArgs e)
        {
            false_p11.Opacity = 1;
            true_p11.Opacity = 0.15;
            pump_check[10] = false;
        }

        /*
        p12
        */

        private void true_p12btn(object sender, MouseButtonEventArgs e)
        {
            false_12.Opacity = 0.15;
            true_p12.Opacity = 1;
            pump_check[11] = true;
        }

        private void false_p12btn(object sender, MouseButtonEventArgs e)
        {
            false_12.Opacity = 1;
            true_p12.Opacity = 0.15;
            pump_check[11] = false;
        }

        /*
        p13
        */

        private void true_p13btn(object sender, MouseButtonEventArgs e)
        {
            false_p13.Opacity = 0.15;
            true_p13.Opacity = 1;
            pump_check[12] = true;
        }

        private void false_p13btn(object sender, MouseButtonEventArgs e)
        {
            false_p13.Opacity = 1;
            true_p13.Opacity = 0.15;
            pump_check[12] = false;
        }

        /*
        p14
        */

        private void true_p14btn(object sender, MouseButtonEventArgs e)
        {
            false_p14.Opacity = 0.15;
            true_p14.Opacity = 1;
            pump_check[13] = true;
        }

        private void false_p14btn(object sender, MouseButtonEventArgs e)
        {
            false_p14.Opacity = 1;
            true_p14.Opacity = 0.15;
            pump_check[13] = false;
        }

        /*
        p15
        */

        private void true_p15btn(object sender, MouseButtonEventArgs e)
        {
            false_15.Opacity = 0.15;
            true_p15.Opacity = 1;
            pump_check[14] = true;
        }

        private void false_p15btn(object sender, MouseButtonEventArgs e)
        {
            false_15.Opacity = 1;
            true_p15.Opacity = 0.15;
            pump_check[14] = false;
        }

        /*
       p16
        */

        private void true_16btn(object sender, MouseButtonEventArgs e)
        {
            false_p16.Opacity = 0.15;
            true_16.Opacity = 1;
            pump_check[15] = true;
        }

        private void false_p16btn(object sender, MouseButtonEventArgs e)
        {
            false_p16.Opacity = 1;
            true_16.Opacity = 0.15;
            pump_check[15] = false;
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
