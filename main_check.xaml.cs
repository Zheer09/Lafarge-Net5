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
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;


namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for main_check.xaml
    /// </summary>
    public partial class main_check : Page
    {

        string Selected_v_index = "";
        string weekly_indexx = "";
        string v_code = "";
        string check_t = "";
        DateTime dt = GlobalClass.GetNistTime();


        public main_check()
        {
            InitializeComponent();
            refreshData();
           

        }


        void refreshData()
        { 
            
            
            
            GlobalClass.con.Open();
            MySqlDataAdapter sql_cmd =
         new MySqlDataAdapter("select mv.maintenance_id as 'ID', mv.weekly_index as 'Weekly ID',  mv.vehicle_code as 'Vehicle Code', lv.vehicle_type as 'Type',  " +
         " mv.vehicle_status as 'Status', mv.Check_type as 'Check Type', " +
         " DATE_FORMAT(mv.maintenance_date, '%Y %M %D') as 'Maintenance Date', " +
         " '     Select    ' as '     Select Row     ' " +
           " from maintenance_vehicle as mv " +
           " join vehicle as lv on mv.vehicle_code = lv.vehicle_code " +
           "  where mv.vehicle_status = 'Unchecked'; ", GlobalClass.con);
           
            //GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            DataTable dt1 = new DataTable();
            sql_cmd.Fill(dt1);

            Uncheck_maintanance.ItemsSource = dt1.DefaultView;

            sql_cmd =
          new MySqlDataAdapter("select mv.maintenance_id as 'ID', mv.weekly_index as 'Weekly ID',   mv.vehicle_code as 'Vehicle Code', lv.vehicle_type as 'Type',  " +
          " mv.vehicle_status as 'Status', mv.Check_type as 'Check Type', " +
          " DATE_FORMAT(mv.maintenance_date, '%Y %M %D') as 'Maintenance Date', " +
          " '     Select    ' as '     Select Row     ' " +
            " from maintenance_vehicle as mv " +
            " join vehicle as lv on mv.vehicle_code = lv.vehicle_code " +
            "  where mv.vehicle_status = 'Processing'; ", GlobalClass.con);


            DataTable dt2 = new DataTable();
            sql_cmd.Fill(dt2);

            Proccessing_maintanance.ItemsSource = dt2.DefaultView;

            GlobalClass.con.Close();

        }


        private void un_Check_maintanance_selection(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("hello man");
            
            DataRowView Selected_vehicle = Uncheck_maintanance.SelectedItem as DataRowView;
            if (Selected_vehicle != null)
            {
                Selected_v_index = Selected_vehicle.Row.ItemArray[0].ToString();
                weekly_indexx = Selected_vehicle.Row.ItemArray[1].ToString() ;
            }

        }



        private void pro_Check_maintanance_selection(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("hello man");

            DataRowView Selected_vehicle = Proccessing_maintanance.SelectedItem as DataRowView;
            if (Selected_vehicle != null)
            {
                Selected_v_index = Selected_vehicle.Row.ItemArray[0].ToString();
                weekly_indexx = Selected_vehicle.Row.ItemArray[1].ToString();
                v_code = Selected_vehicle.Row.ItemArray[2].ToString();
                check_t = Selected_vehicle.Row.ItemArray[5].ToString();

            }

        }


        private void Button_Click_View_Vehicle(object sender, RoutedEventArgs e)
        {



            if (Selected_v_index == "")
            {
                MessageBox.Show("You haven't selected any vehicle!");
            }
            else
            {

                ViewMaintenanceVehicle vmv = new ViewMaintenanceVehicle(Selected_v_index, weekly_indexx);
                
                vmv.ShowDialog();

            }



        }

        private void Button_Click_set_to_Pro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to set Vehicle to Processing state?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                try
                {

                    GlobalClass.con.Open();

                    MySqlCommand updateQuery = new MySqlCommand("UPDATE maintenance_vehicle set vehicle_status = 'Processing' where maintenance_id = " + Selected_v_index + ";", GlobalClass.con);

                    updateQuery.ExecuteNonQuery();

                    GlobalClass.con.Close();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
          
            }
            else
            {

            }
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            refreshData();
        }

        private void View_done_m_vehicle_Click(object sender, RoutedEventArgs e)
        {

            if (Selected_v_index == "")
            {
                MessageBox.Show("You haven't selected any vehicle!");
            }
            else
            {

                ViewMaintenanceVehicle vmv = new ViewMaintenanceVehicle(Selected_v_index, weekly_indexx);

                vmv.ShowDialog();

            }

        }

        private void set_done_Click(object sender, RoutedEventArgs e)
        {

            if (Selected_v_index == "")
            {
                MessageBox.Show("You haven't selected any vehicle!");
            }
            else
            {
                if (MessageBox.Show("Do you want to set this Vehicle to Done state?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {


                    GlobalClass.con.Open();

                    MySqlCommand updateQuery = new MySqlCommand("UPDATE maintenance_vehicle set vehicle_status = 'Done' where maintenance_id = " + Selected_v_index + ";", GlobalClass.con);

                    updateQuery.ExecuteNonQuery();

                    //////////////////////
                    ///

                    int[] AllFalseCheck = new int[16];
                    int ii = 0;

                    /*
                    select false_check_rep from weekly_checks_sub where 
                    weekly_index =  2
                    and vehicle_code = 'M44'
                    order by check_rep_date desc ;
                     */


                    //GlobalClass.con.Open();


                    string command_select2 = "select false_check_rep from weekly_checks_sub where " +
                        " weekly_index = " + weekly_indexx + " and vehicle_code = '" + v_code + "' " +
                        " order by check_rep_date desc limit 16 ; ";
                    MySqlCommand sql_cmd2 = new MySqlCommand(command_select2, GlobalClass.con);
                    GlobalClass.sql_dr = sql_cmd2.ExecuteReader();

                    while (GlobalClass.sql_dr.Read())
                    {

                        AllFalseCheck[ii] = GlobalClass.sql_dr.GetInt32(0);
                        ii += 1;

                    }

                    GlobalClass.sql_dr.Close();



                    ///////////////////////


                    MySqlCommand insert_report_cmd = new MySqlCommand(" insert into maintenance_report (check_type, vehicle_status, maintenance_date) " +
                        " values ( '"+check_t+"', 'Done', '"+dt.ToString("yyyy-MM-dd")+"' ) ", GlobalClass.con);

                    GlobalClass.sql_dr = insert_report_cmd.ExecuteReader();

                    GlobalClass.sql_dr.Close();


                    MySqlCommand getLatestID = new MySqlCommand("select report_id from  maintenance_report where maintenance_date = '" + dt.ToString("yyyy-MM-dd") + "' " +
                        " order by maintenance_date desc limit 1; ", GlobalClass.con);
                    
                    GlobalClass.sql_dr = getLatestID.ExecuteReader();

                    GlobalClass.sql_dr.Read();
                    int currentReportID = GlobalClass.sql_dr.GetInt32(0);
                    GlobalClass.sql_dr.Close();

                    ///////////////////////

                    string sql_insert_query = " insert into maintenance_report_sub (report_id, check_rep_index, false_check_rep) values ";
                        for(int i = 0; i < 15; i++)
                    {
                        sql_insert_query += " ( " + currentReportID +", " + (i+1) +", " + AllFalseCheck[i] +" ), ";
                    }
                        sql_insert_query += " ( " + currentReportID + ", " + 16 + ", " + AllFalseCheck[15] + " ); ";

                    MySqlCommand insert_report_sub_cmd = new MySqlCommand( sql_insert_query , GlobalClass.con);
                    GlobalClass.sql_dr = insert_report_sub_cmd.ExecuteReader();

                    GlobalClass.sql_dr.Close();

                    ///////////////////

                    string updateStringSub = " update weekly_checks_sub set " +
                        " false_check_rep = 0 " +
                        " where false_check_rep >= 5 and " +
                        " vehicle_code = '"+ v_code + "' and" +
                        " weekly_index = " +weekly_indexx+ "; ";

                    MySqlCommand updateWeekly = new MySqlCommand(updateStringSub, GlobalClass.con);

                    GlobalClass.sql_dr = updateWeekly.ExecuteReader();

                    GlobalClass.con.Close();


                }
            }

        }
    }
}
