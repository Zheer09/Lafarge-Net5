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
    /// Interaction logic for Pump_Check.xaml
    /// </summary>
    public partial class Pump_Check : Page
    {
        bool[] pump_check = new bool[16];
        string[] pump_note = new string[16];
        readonly string v_type = "Pump";
        double last_wh = 0;
        double change_wh = 0;
        double wh_50 = 0;
        double wh_300 = 0;
        int num_of_index_v_ch = 0;
        int num_of_index_w_r = 0;
        DateTime s_d;
        bool insert_status = false;
        int[] lastRep = new int[16];
        int myIndex = 0;
        bool h50_condition = false;
        bool h300_condition = false;

        public Pump_Check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("yyyy-MM-dd HH:mm");

            for (int i = 0; i < 16; i++)
            {
                pump_check[i] = true;
            }

            s_d = GlobalClass.GetNistTime();


        }

        private bool validateSubmit()
        {

            // code...


            return false;
        }


        /*
      p1
      */

        private void P1_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[0] = true;
        }

        private void P1_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[0] = false;
        }



        private void P2_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[1] = false;
        }

        private void P2_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[1] = true;
        }



        private void P3_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[2] = false;
        }

        private void P3_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[2] = true;
        }



        private void P4_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[3] = true;
        }

        private void P4_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[3] = false;
        }



        private void P5_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[4] = true;
        }

        private void P5_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[4] = false;
        }



        private void P6_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[5] = true;
        }

        private void P6_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[5] = false;
        }



        private void P7_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[6] = true;
        }

        private void P7_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[6] = false;
        }



        private void P8_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[7] = false;
        }

        private void P8_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[7] = true;
        }



        private void P9_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[8] = true;
        }

        private void P9_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[8] = false;
        }



        private void P10_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[9] = true;
        }

        private void P10_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[9] = false;
        }



        private void P11_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[10] = true;
        }

        private void P11_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[10] = false;
        }



        private void P12_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[11] = true;
        }

        private void P12_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[11] = false;
        }



        private void P13_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[12] = true;
        }

        private void P13_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[12] = false;
        }



        private void P14_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[13] = true;
        }

        private void P14_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[13] = false;
        }



        private void P15_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[14] = true;
        }

        private void P15_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[14] = false;
        }



        private void P16_YesButtonChecked(object sender, EventArgs e)
        {
            pump_check[15] = true;
        }

        private void P16_NoButtonChecked(object sender, EventArgs e)
        {
            pump_check[15] = false;
        }

        private void DatePicker_selectedDate_changed(object sender, SelectionChangedEventArgs e)
        {

            s_d = (DateTime)(((DatePicker)sender).SelectedDate);
            DateTime_lable.Text = s_d.ToString("yyyy-MM-dd");

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            pump_note[0] = Note_p1.Text;
            pump_note[1] = Note_p2.Text;
            pump_note[2] = Note_p3.Text;
            pump_note[3] = Note_p4.Text;
            pump_note[4] = Note_p5.Text;
            pump_note[5] = Note_p6.Text;
            pump_note[6] = Note_p7.Text;
            pump_note[7] = Note_p8.Text;
            pump_note[8] = Note_p9.Text;
            pump_note[9] = Note_p10.Text;
            pump_note[10] = Note_p11.Text;
            pump_note[11] = Note_p12.Text;
            pump_note[12] = Note_p13.Text;
            pump_note[13] = Note_p14.Text;
            pump_note[14] = Note_p15.Text;
            pump_note[15] = Note_p16.Text;
            h50_condition = false;
            h300_condition = false;
            v_code.Text = v_code.Text.ToUpper();



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
                if (MessageBox.Show("Do you want to Save?", "Confirm",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                {

                    if (GlobalOperations.doesVehicleExist(v_code.Text))
                    {


                        MessageBox.Show("Here 1");


                        SelectVehicleProperty my_v_p = new SelectVehicleProperty();
                        my_v_p = GlobalOperations.getVehicleProperty(v_code.Text);

                        MessageBox.Show("Here 2");

                        last_wh = my_v_p.working_hour;
                        wh_50 = my_v_p.wh_50h;
                        wh_300 = my_v_p.wh_300h;

                        if (last_wh >= double.Parse(working_hours.Text))
                        {
                            MessageBox.Show("Invalid Working Hour! Please Enter data carefully.");
                        }
                        else
                        {



                            // logic behind the working hour stuff.
                            change_wh = double.Parse(working_hours.Text) - last_wh;
                            wh_50 += change_wh;
                            wh_300 += change_wh;

                            //s_d = new DateTime(2021, 4, 2);

                            if (wh_50 >= 50)
                            {
                                // send into 50 hour maintenance check...                                       /////
                                wh_50 -= 50;

                                h50_condition = true;



                            }
                            if (wh_300 >= 300)
                            {
                                // send into 300 hour maintenance check...                                      /////
                                wh_300 -= 300;
                                h300_condition = true;


                            }


                            GlobalOperations.Insert_into_vehicle_property(v_code.Text, double.Parse(working_hours.Text), wh_50, wh_300, s_d);

                            MessageBox.Show("Here 3");


                            num_of_index_w_r = GlobalOperations.GetIndexNumber_w_r();
                            GlobalOperations.Insert_into_weekly_reports((1 + num_of_index_w_r), v_code.Text, " ", s_d);

                            MessageBox.Show("Here 4");

                            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                            string concatString = " ";

                            num_of_index_v_ch = GlobalOperations.GetIndexNumber_v_ch();

                            MessageBox.Show("Here 5");

                            for (int i = 1; i < 17; i++)
                            {
                                if (i != 16)
                                {

                                    concatString += "(" + (i + num_of_index_v_ch) + ", " + i + ", " + pump_check[i - 1] + ", '" +
                                    pump_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'), ";

                                }
                                else
                                {

                                    concatString += "(" + (i + num_of_index_v_ch) + ",  " + 16 + ", " + pump_check[i - 1] + ", '" +
                                    pump_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'); ";

                                }
                            }



                            GlobalClass.con.Open();


                            string command_insert = "INSERT INTO vehicle_check ( check_id, check_index, check_result, check_note, vehicle_code, submit_date) VALUES " + concatString;

                            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
                            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

                            GlobalClass.con.Close();

                            MessageBox.Show("Here 6");

                            int last_week_index = GlobalOperations.getLastWeeklyIndex(v_code.Text, (num_of_index_w_r + 1));



                            string con_strrr_append = " ";

                            string con_last_check_command = " select a.false_check_rep from weekly_checks_sub as a where " +
                                                "  a.weekly_index = " + last_week_index +
                                               " and a.vehicle_code = '" + v_code.Text + "' " +
                                                " order by a.check_rep_date desc " +
                                                " limit 16; ";

                            GlobalClass.con.Open();

                            MySqlCommand sql_cmd_neww = new MySqlCommand(con_last_check_command, GlobalClass.con);
                            GlobalClass.sql_dr = sql_cmd_neww.ExecuteReader();
                            while (GlobalClass.sql_dr.Read())
                            {
                                lastRep[myIndex] = GlobalClass.sql_dr.GetInt32(0);
                                myIndex += 1;
                            }
                            myIndex = 0;

                            MessageBox.Show("Here 7");

                            GlobalClass.con.Close();


                            // this is to insert fasle checks into sub
                            for (int i = 0; i < 16; i++)
                            {


                                if (i != 15)
                                {

                                    if (pump_check[i] == false)
                                    {

                                        lastRep[i] += 1;

                                        con_strrr_append += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + lastRep[i] + ", '" + s_d.ToString(format) + "' ), ";

                                    }
                                    else
                                    {
                                        con_strrr_append += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + lastRep[i] + ",  '" + s_d.ToString(format) + "' ), ";
                                    }
                                }
                                else if (i == 15)
                                {
                                    if (pump_check[i] == false)
                                    {

                                        lastRep[i] += 1;

                                        con_strrr_append += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + lastRep[i] + ",  '" + s_d.ToString(format) + "' );";

                                    }
                                    else
                                    {
                                        con_strrr_append += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + lastRep[i] + ",  '" + s_d.ToString(format) + "' );";
                                    }
                                }

                                    

                                }

                            string command_insert_2 = "INSERT INTO weekly_checks_sub ( vehicle_code ,check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES" + con_strrr_append;
                            //INSERT INTO weekly_checks_sub(vehicle_code, check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES
                            GlobalClass.con.Open();


                            MySqlCommand sql_cmd_2 = new MySqlCommand(command_insert_2, GlobalClass.con);
                            GlobalClass.sql_dr = sql_cmd_2.ExecuteReader();
                            GlobalClass.con.Close();


                            MessageBox.Show("Here 8");



                            if (h50_condition)
                            {
                                // insert into maintenance vehicle page
                                GlobalOperations.insert_maintenance_vehicle(v_code.Text, (1 + num_of_index_w_r), "50 Hour Check", "Unchecked", s_d);

                                MessageBox.Show("Here 9");


                                string w1 = "", w2 = "", w3 = "", w4 = "";
                                string w1_s = "", w2_s = "", w3_s = "", w4_s = "";
                                // this is to indicate which week are we currently in 
                                int firstTime = 0;


                                if (Int32.Parse(s_d.ToString("dd")) <= 8)
                                {
                                    w1 = "2";
                                    w1_s = "Unchecked";
                                    firstTime = 1;

                                }
                                else if (Int32.Parse(s_d.ToString("dd")) <= 16)
                                {
                                    w2 = "2";
                                    w2_s = "Unchecked";
                                    firstTime = 2;

                                }
                                else if (Int32.Parse(s_d.ToString("dd")) <= 23)
                                {
                                    w3 = "2";
                                    w3_s = "Unchecked";
                                    firstTime = 3;
                                }
                                else if (Int32.Parse(s_d.ToString("dd")) <= 31)
                                {
                                    w4 = "2";
                                    w4_s = "Unchecked";
                                    firstTime = 4;
                                }


                                GlobalClass.con.Open();

                                int currentDays = Convert.ToInt32(s_d.ToString("dd"));

                                DateTime tempDate = s_d;

                                DateTime monthStart = tempDate.AddDays(currentDays);

                                MySqlCommand checkMonthly = new MySqlCommand("  select count(*) from monthly_report where vehicle_code = '" + v_code.Text + "' " +
                                    " and monthly_date >= '" + monthStart.ToString("yyyy-MM-dd") + "';   ", GlobalClass.con);

                                GlobalClass.sql_dr = checkMonthly.ExecuteReader();
                                int isThereData = 0;
                                if (GlobalClass.sql_dr.HasRows)
                                {
                                    GlobalClass.sql_dr.Read();
                                    isThereData = GlobalClass.sql_dr.GetInt32(0);

                                    MessageBox.Show("Here 10");

                                }
                                else
                                {
                                    isThereData = 0;
                                }

                                if (isThereData == 0)
                                {
                                    string command_insert_3 = "INSERT INTO monthly_report (vehicle_code, 50hr_w1, w1_status, 50hr_w2, w2_status, 50hr_w3, w3_status, 50hr_w4, w4_status, workingHours, monthly_date ) VALUES " +
                                        " ('" + v_code.Text + "', '" + w1 + "', '" + w1_s + "',  '" + w2 + "', '" + w2_s + "', '" + w3 + "', '" + w3_s + "', '" + w4 + "', '" + w4_s + "', " + working_hours.Text + ", '" + s_d.ToString("yyyy-MM-dd HH:mm:ss") + "' );";
                                    GlobalClass.sql_dr.Close();
                                    MySqlCommand sql_cmd_3 = new MySqlCommand(command_insert_3, GlobalClass.con);
                                    GlobalClass.sql_dr = sql_cmd_3.ExecuteReader();
                                    GlobalClass.sql_dr.Close();

                                    MessageBox.Show("Here 11");

                                }
                                else if (isThereData == 1)
                                {
                                    string command99 = "";
                                    if (firstTime == 2)
                                    {
                                        command99 = " update monthly_report set 50hr_w2 = '2', w2_status = 'Unchecked' where vehicle_code = '" + v_code.Text + "' " +
                                            " and monthly_date >= '" + monthStart.ToString("yyyy-MM-dd") + "' ; ";

                                    }
                                    else if (firstTime == 3)
                                    {
                                        command99 = " update monthly_report set 50hr_w3 = '2', w3_status = 'Unchecked' where vehicle_code = '" + v_code.Text + "' " +
                                            " and monthly_date >= '" + monthStart.ToString("yyyy-MM-dd") + "' ; ";
                                    }
                                    else if (firstTime == 4)
                                    {
                                        command99 = " update monthly_report set 50hr_w4 = '2', w4_status = 'Unchecked' where vehicle_code = '" + v_code.Text + "' " +
                                            " and monthly_date >= '" + monthStart.ToString("yyyy-MM-dd") + "' ; ";
                                    }


                                    MySqlCommand updataW1 = new MySqlCommand(command99, GlobalClass.con);
                                    updataW1.ExecuteNonQuery();

                                }


                                GlobalClass.con.Close();


                            }
                            if (h300_condition)
                            {
                                //insert into maintenance vehicle page
                                GlobalOperations.insert_maintenance_vehicle(v_code.Text, (1 + num_of_index_w_r), "300 Hour Check", "Unchecked", s_d);

                                GlobalClass.con.Open();

                                string command_insert_3 = "INSERT INTO monthly_report (vehicle_code, 300hr_m, monthly_status, workingHours, monthly_date ) VALUES " +
                                    " ('" + v_code.Text + "', '3', 'Unchecked', " + working_hours.Text + ", '" + s_d.ToString("yyyy-MM-dd HH:mm:ss") + "' );";
                                MySqlCommand sql_cmd_3 = new MySqlCommand(command_insert_3, GlobalClass.con);
                                GlobalClass.sql_dr = sql_cmd_3.ExecuteReader();
                                GlobalClass.con.Close();

                            }


                            insert_status = true;
                        }

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

                                concatString += "(" + (i + num_of_index_v_ch) + ", " + i + ", " + pump_check[i - 1] + ", '" + pump_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'), ";

                            }
                            else
                            {

                                concatString += "(" + (i + num_of_index_v_ch) + ",  " + 16 + ", " + pump_check[i - 1] + ", '" + pump_note[i - 1] + "', '" + v_code.Text + "',  '" + s_d.ToString(format) + "'); ";

                            }
                        }

                        string command_insert = "INSERT INTO vehicle_check ( check_id, check_index, check_result, check_note, vehicle_code, submit_date) VALUES " + concatString;


                        MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd.ExecuteReader();
                        GlobalClass.con.Close();


                        num_of_index_w_r = GlobalOperations.GetIndexNumber_w_r();
                        GlobalOperations.Insert_into_weekly_reports((1 + num_of_index_w_r), v_code.Text, " ", s_d);


                        //string command_insert_3 = "INSERT INTO weekly_checks_sub ( vehicle_code ,check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES";
                        string concat_string_new = " ";


                        // this is to insert fasle checks into sub
                        for (int i = 0; i < 16; i++)
                        {


                            if (i != 15)
                            {

                                if (pump_check[i] == false)
                                {




                                    concat_string_new += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + 1 + ",  '" + s_d.ToString(format) + "' ),";



                                }
                                else
                                {
                                    concat_string_new += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + 0 + ",  '" + s_d.ToString(format) + "' ),";
                                }
                            }
                            else if (i == 15)
                            {
                                if (pump_check[i] == false)
                                {


                                    concat_string_new += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + 1 + ",  '" + s_d.ToString(format) + "' );";



                                }
                                else
                                {
                                    concat_string_new += " ( '" + v_code.Text + "', " + (i + 1) + ", " + (1 + num_of_index_w_r) + ", " + 0 + ",  '" + s_d.ToString(format) + "' );";
                                }
                            }

                        }


                        string command_insert_3 = "INSERT INTO weekly_checks_sub ( vehicle_code ,check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES" + concat_string_new;
                        //INSERT INTO weekly_checks_sub(vehicle_code, check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES
                        GlobalClass.con.Open();


                        MySqlCommand sql_cmd_3 = new MySqlCommand(command_insert_3, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd_3.ExecuteReader();
                        GlobalClass.con.Close();



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
                else
                {
                    // Cancel code here  
                }

            }
        }

        private void Goback_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.vehicle());
        }
    }
}
