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
using MySql.Data.MySqlClient;


namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for Loader_check.xaml
    /// </summary>
    public partial class Loader_check : Page
    {

        bool[] loader_check = new bool[16];
        string[] loader_note = new string[16];
        readonly string v_type = "Loader";
        double last_wh = 0;
        double change_wh = 0;
        double wh_50 = 0;
        double wh_300 = 0;
        int num_of_index_v_ch = 0;
        int num_of_index_w_r = 0;
        DateTime s_d;
        bool insert_status = false;
        int currentFasleCheck_num = 0;

       

        public Loader_check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("yyyy-MM-dd HH:mm");
            
            for(int i = 0; i < 16; i++)
            {
                loader_check[i] = true;
            }

            s_d = GlobalClass.GetNistTime();

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

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Goback_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.vehicle());
        }




      /*  private bool addInto_wr_sub()
        {

        }*/


        // MAIN FUNCTION
        // this is where everything happens man.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            loader_note[0] = Note_p1.Text;
            loader_note[1] = Note_p2.Text;
            loader_note[2] = Note_p3.Text;
            loader_note[3] = Note_p4.Text;
            loader_note[4] = Note_p5.Text;
            loader_note[5] = Note_p6.Text;
            loader_note[6] = Note_p7.Text; 
            loader_note[7] = Note_p8.Text;
            loader_note[8] = Note_p9.Text;
            loader_note[9]= Note_p10.Text;
            loader_note[10]= Note_p11.Text;
            loader_note[11] = Note_p12.Text;
            loader_note[12] = Note_p13.Text;
            loader_note[13] = Note_p14.Text;
            loader_note[14] =  Note_p15.Text;
            loader_note[15] = Note_p16.Text;


            if (v_code.Text == "")
            {
                MessageBox.Show("Vehicle Code field is required!");
            }
            else if (batch_plant.Text == "")
            {
                MessageBox.Show("Batch Plant field is required!");
            }
            else if (working_hours.Text == "")
            {
                MessageBox.Show("Working Hours field is required!");
            }
            else
            {


                try
                {

                    if (GlobalOperations.doesVehicleExist(v_code.Text))
                    {

                        MessageBox.Show("Got here! 1");
                        SelectVehicleProperty my_v_p = new SelectVehicleProperty();
                        my_v_p = GlobalOperations.getVehicleProperty(v_code.Text);


                        MessageBox.Show("Got here! 1.55");

                        last_wh = my_v_p.working_hour;
                        wh_50 = my_v_p.wh_50h;
                        wh_300 = my_v_p.wh_300h;

                        // logic behind the working hour stuff.
                        change_wh = double.Parse(working_hours.Text) - last_wh;
                        wh_50 += change_wh;
                        wh_300 += change_wh;


                        MessageBox.Show("Got here! 2");
                        if (wh_50 >= 50)
                        {
                            // send into 50 hour maintenance check...                                       /////
                            wh_50 -= 50;
                        }
                        if(wh_300 >= 300)
                        {
                            // send into 300 hour maintenance check...                                      /////
                            wh_300 -= 300;
                        }

                        MessageBox.Show("Got here! 3");

                        GlobalOperations.Insert_into_vehicle_property(v_code.Text, double.Parse(working_hours.Text), wh_50, wh_300, s_d);

                        MessageBox.Show("Got here! 4");

                        num_of_index_w_r = GlobalOperations.GetIndexNumber_w_r();
                        GlobalOperations.Insert_into_weekly_reports((1 + num_of_index_w_r), v_code.Text, " ", s_d);

                        MessageBox.Show("Got here! 5");

                        string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                        string concatString = " ";

                        num_of_index_v_ch = GlobalOperations.GetIndexNumber_v_ch();

                        for (int i = 1; i < 17; i++)
                        {
                            if (i != 16)
                            {

                                concatString += "(" + (i + num_of_index_v_ch) + ", " + i + ", " + loader_check[i - 1] + ", '" + 
                                loader_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'), ";

                            }
                            else
                            {

                                concatString += "(" + (i + num_of_index_v_ch) + ",  " + 16 + ", " + loader_check[i - 1] + ", '" + 
                                loader_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'); ";

                            }
                        }

                        MessageBox.Show("Got here! 6");

                        GlobalClass.con.Open();


                        string command_insert = "INSERT INTO vehicle_check ( check_id, check_index, check_result, check_note, vehicle_code, submit_date) VALUES " + concatString;

                        MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd.ExecuteReader();
                        GlobalClass.con.Close();

                        MessageBox.Show("Got here! 7");

                        // this is to insert fasle checks into sub
                        for (int i = 0; i < 16; i++)
                        {

                            // I need to get last weekly index according to max date and vehicle code
                            int last_week_index = GlobalOperations.getLastWeeklyIndex(v_code.Text, (num_of_index_w_r + 1));

                            MessageBox.Show("Passed this " + i);

                            currentFasleCheck_num = GlobalOperations.getLastFalseCheck((i + 1), last_week_index, v_code.Text);



                            if (loader_check[i] == false)
                            {


                                currentFasleCheck_num += 1;

                                MessageBox.Show("got here 7." + i );


                               GlobalOperations.Insert_into_weekly_checks_sub(v_code.Text, (i + 1), (1 + num_of_index_w_r), currentFasleCheck_num, s_d);


                            }
                            else
                            {
                                GlobalOperations.Insert_into_weekly_checks_sub(v_code.Text, (i + 1), (1 + num_of_index_w_r), currentFasleCheck_num, s_d);
                            }

                        }



                        insert_status = true;
                        MessageBox.Show("Got here! 8 donnneeeee!");

                    }
                    else //  if the vehicle doesn't exist
                    {
                        
                        num_of_index_v_ch = GlobalOperations.GetIndexNumber_v_ch();

                        GlobalOperations.Insert_into_vehicle(v_code.Text, v_type, batch_plant.Text.ToString());
                        GlobalOperations.Insert_into_vehicle_property(v_code.Text, double.Parse(working_hours.Text), 0, 0, s_d);


                        GlobalClass.con.Open();
                        string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                        string concatString = " ";

                        for (int i = 1; i < 17; i++)
                        {
                            if (i != 16)
                            {

                                concatString += "(" + (i + num_of_index_v_ch) + ", "+ i +", " + loader_check[i - 1] + ", '" + loader_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'), ";
                            
                            }
                            else
                            {

                                concatString += "(" + (i + num_of_index_v_ch) + ",  "+ 16 +", " + loader_check[i - 1] + ", '" + loader_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'); ";

                            }
                        }

                        string command_insert = "INSERT INTO vehicle_check ( check_id, check_index, check_result, check_note, vehicle_code, submit_date) VALUES " + concatString;


                        MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd.ExecuteReader();
                        GlobalClass.con.Close();


                        num_of_index_w_r = GlobalOperations.GetIndexNumber_w_r();
                        GlobalOperations.Insert_into_weekly_reports((1 + num_of_index_w_r), v_code.Text, " ", s_d);


                        // this is to insert fasle checks into sub
                        for (int i = 0; i < 16; i++)
                        {
                            if (loader_check[i] == false)
                            {

                                

                                GlobalOperations.Insert_into_weekly_checks_sub(v_code.Text, (i + 1), (1 + num_of_index_w_r), 1, s_d);

                                // this has to insert the weekly sub and update the false check rep 
                                // it should be different from a vehicle that doesn't exist
                                //you have modify the functions in the globalOperations class for inserting and updating.

                            }
                            else
                            {
                                GlobalOperations.Insert_into_weekly_checks_sub(v_code.Text, (i + 1), (1 + num_of_index_w_r), 0, s_d);
                            }

                        }




                        insert_status = true;

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    insert_status = false;
                }


                if (insert_status == true)
                {
                    MessageBox.Show("Data has been successfully saved for vehicle: " + v_code.Text + ".");
                    this.NavigationService.Navigate(new Pages.vehicle());
                }
                else
                {
                    MessageBox.Show("An error has occurred! The data was not fully Saved.");
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
