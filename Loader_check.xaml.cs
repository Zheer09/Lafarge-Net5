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

        bool[] loader_check = new bool[16];
        string[] loader_note = new string[16];
        string v_type = "Loader";
        double last_wh = 0, new_wh = 0;
        double wh_50 = 0;
        double wh_300 = 0;

       

        public Loader_check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("dd MMMM yyyy");
            //MessageBox.Show(GlobalClass.GetNistTime().ToString("dd MMMM yyyy"));
            for(int i = 0; i < 16; i++)
            {
                loader_check[i] = true;
            }



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

            Note_p1.Text = loader_note[0];
            Note_p2.Text = loader_note[1];
            Note_p3.Text = loader_note[2];
            Note_p4.Text = loader_note[3];
            Note_p5.Text = loader_note[4];
            Note_p6.Text = loader_note[5];
            Note_p7.Text = loader_note[6];
            Note_p8.Text = loader_note[7];
            Note_p9.Text = loader_note[8];
            Note_p10.Text = loader_note[9];
            Note_p11.Text = loader_note[10];
            Note_p12.Text = loader_note[11];
            Note_p13.Text = loader_note[12];
            Note_p14.Text = loader_note[13];
            Note_p15.Text = loader_note[14];
            Note_p16.Text = loader_note[15];


            if (GlobalOperations.doesVehicleExist( v_code.Text ))
            {

                SelectVehicleProperty my_v_p = GlobalOperations.getVehicleProperty(v_code.Text);
                last_wh = my_v_p.working_hour;
                wh_50 = my_v_p.wh_50h;
                wh_300 = my_v_p.wh_300h;

                new_wh = double.Parse(working_hours.Text) - last_wh;
                wh_50 += new_wh;
                wh_300 += new_wh;




            }
            else
            {
                

                GlobalOperations.Insert_into_vehicle(v_code.Text, v_type, batch_plant.Text.ToString() );
                GlobalOperations.Insert_into_vehicle_property(v_code.Text, double.Parse(working_hours.Text), 0, 0, GlobalClass.GetNistTime());
                for(int i = 0; i < 16; i++)
                {
                    GlobalOperations.Insert_into_vehicle_check(i, loader_check[i], loader_note[i], v_code.Text, GlobalClass.GetNistTime());
                }
               
            }



        }

        /*
       p1
       */

        private void true_p1btn(object sender, MouseButtonEventArgs e)
        {
            false_p1.Opacity = 0.15;
            true_p1.Opacity = 1;
            loader_check[0] = true;
        }

        private void false_p1btn(object sender, MouseButtonEventArgs e)
        {
            false_p1.Opacity = 1;
            true_p1.Opacity =0.15;
            loader_check[0] = false;
        }

        /*
         p2
         */
        private void true_p2btn(object sender, MouseButtonEventArgs e)
        {
            false_p2.Opacity = 0.15;
            true_p2.Opacity = 1;
            loader_check[1] = true;
        }

        private void false_p2btn(object sender, MouseButtonEventArgs e)
        {
            false_p2.Opacity = 1;
            true_p2.Opacity = 0.15;
            loader_check[1] = false;
           
        }

        /*
        p3
        */

        private void true_p3btn(object sender, MouseButtonEventArgs e)
        {

            false_p3.Opacity = 0.15;
            true_p3.Opacity = 1;
            loader_check[2] = true;

        }

        private void false_p3btn(object sender, MouseButtonEventArgs e)
        {
            false_p3.Opacity = 1;
            true_p3.Opacity = 0.15;
            loader_check[2] = false;
        }

        /*
        p4
        */

        private void true_p4btn(object sender, MouseButtonEventArgs e)
        {
            false_p4.Opacity = 0.15;
            true_p4.Opacity = 1;
            loader_check[3] = true;
        }

        private void false_p4btn(object sender, MouseButtonEventArgs e)
        {
            false_p4.Opacity = 1;
            true_p4.Opacity = 0.15;
            loader_check[3] = false;
        }

        /*
       p5
       */

        private void true_p5btn(object sender, MouseButtonEventArgs e)
        {
            false_p5.Opacity = 0.15;
            true_p5.Opacity = 1;
            loader_check[4] = true;
        }

        private void false_p5btn(object sender, MouseButtonEventArgs e)
        {
            false_p5.Opacity = 1;
            true_p5.Opacity = 0.15;
            loader_check[4] = false;
        }

        /*
            p6
        */

        private void true_p6btn(object sender, MouseButtonEventArgs e)
        {
            false_p6.Opacity = 0.15;
            true_p6.Opacity = 1;
            loader_check[5] = true;
        }

        private void false_p6btn(object sender, MouseButtonEventArgs e)
        {
            false_p6.Opacity = 1;
            true_p6.Opacity = 0.15;
            loader_check[5] = false;
        }

        /*
            p7
        */

        private void true_p7btn(object sender, MouseButtonEventArgs e)
        {
            false_p7.Opacity = 0.15;
            true_7.Opacity = 1;
            loader_check[6] = true;
        }

        private void false_p7btn(object sender, MouseButtonEventArgs e)
        {
            false_p7.Opacity = 1;
            true_7.Opacity = 0.15;
            loader_check[6] = false;
        }

        /*
        p8
        */

        private void true_p8btn(object sender, MouseButtonEventArgs e)
        {
            false_p8.Opacity = 0.15;
            true_p8.Opacity = 1;
            loader_check[7] = true;
        }

        private void false_p8btn(object sender, MouseButtonEventArgs e)
        {
            false_p8.Opacity = 1;
            true_p8.Opacity = 0.15;
            loader_check[7] = false;
        }

        /*
        p9
        */

        private void true_p9btn(object sender, MouseButtonEventArgs e)
        {
            false_p9.Opacity = 0.15;
            true_p9.Opacity = 1;
            loader_check[8] = true;
        }

        private void false_p9btn(object sender, MouseButtonEventArgs e)
        {
            false_p9.Opacity = 1;
            true_p9.Opacity = 0.15;
            loader_check[8] = false;
        }

        /*
        p10
        */

        private void true_p10btn(object sender, MouseButtonEventArgs e)
        {
            false_p10.Opacity = 0.15;
            true_p10.Opacity = 1;
            loader_check[9] = true;
        }

        private void false_p10btn(object sender, MouseButtonEventArgs e)
        {
            false_p10.Opacity = 1;
            true_p10.Opacity = 0.15;
            loader_check[9] = false;
        }

        /*
        p11
        */

        private void true_p11btn(object sender, MouseButtonEventArgs e)
        {
            false_p11.Opacity = 0.15;
            true_p11.Opacity = 1;
            loader_check[10] = true;
        }

        private void false_p11btn(object sender, MouseButtonEventArgs e)
        {
            false_p11.Opacity = 1;
            true_p11.Opacity = 0.15;
            loader_check[10] = false;
        }

        /*
        p12
        */

        private void true_p12btn(object sender, MouseButtonEventArgs e)
        {
            false_12.Opacity = 0.15;
            true_p12.Opacity = 1;
            loader_check[11] = true;
        }

        private void false_p12btn(object sender, MouseButtonEventArgs e)
        {
            false_12.Opacity = 1;
            true_p12.Opacity = 0.15;
            loader_check[11] = false;
        }

        /*
        p13
        */

        private void true_p13btn(object sender, MouseButtonEventArgs e)
        {
            false_p13.Opacity = 0.15;
            true_p13.Opacity = 1;
            loader_check[12] = true;
        }

        private void false_p13btn(object sender, MouseButtonEventArgs e)
        {
            false_p13.Opacity = 1;
            true_p13.Opacity = 0.15;
            loader_check[12] = false;
        }

        /*
        p14
        */

        private void true_p14btn(object sender, MouseButtonEventArgs e)
        {
            false_p14.Opacity = 0.15;
            true_p14.Opacity = 1;
            loader_check[13] = true;
        }

        private void false_p14btn(object sender, MouseButtonEventArgs e)
        {
            false_p14.Opacity = 1;
            true_p14.Opacity = 0.15;
            loader_check[13] = false;
        }

        /*
        p15
        */

        private void true_p15btn(object sender, MouseButtonEventArgs e)
        {
            false_15.Opacity = 0.15;
            true_p15.Opacity = 1;
            loader_check[14] = true;
        }

        private void false_p15btn(object sender, MouseButtonEventArgs e)
        {
            false_15.Opacity = 1;
            true_p15.Opacity = 0.15;
            loader_check[14] = false;
        }

        /*
       p16
        */

        private void true_16btn(object sender, MouseButtonEventArgs e)
        {
            false_p16.Opacity = 0.15;
            true_16.Opacity = 1;
            loader_check[15] = true;
        }

        private void false_p16btn(object sender, MouseButtonEventArgs e)
        {
            false_p16.Opacity = 1;
            true_16.Opacity = 0.15;
            loader_check[15] = false;
        }


    }
}
