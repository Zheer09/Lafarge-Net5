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
    /// Interaction logic for Loader_check.xaml
    /// </summary>
    public partial class Loader_check : Page
    {
        public Loader_check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("dd MMMM yyyy");
            //MessageBox.Show(GlobalClass.GetNistTime().ToString("dd MMMM yyyy"));
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Goback_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.vehicle());
        }

        // this function checks if every check has been selected and if the required textboxes are filled.
        private bool validateSubmit()
        {

            // code...


            return false;
        }


        // MAIN FUNCTION
        // this is where everything happens man.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

<<<<<<< HEAD
/*
            if (GlobalOperations.doesVehicleExist("L385"))
            {
                MessageBox.Show("It Exists!");
            }
            else
            {
                MessageBox.Show("It doesn't exist bitch bitch");
            }
*/
=======
>>>>>>> cb0a7a77320cb708622ebada28bed6dea9387073

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


    }
}
