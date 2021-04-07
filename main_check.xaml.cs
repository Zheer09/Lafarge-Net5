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


        public main_check()
        {
            InitializeComponent();

            MySqlDataAdapter sql_cmd =
          new MySqlDataAdapter("select mv.maintenance_id as 'ID', mv.vehicle_code as 'Vehicle Code', lv.vehicle_type as 'Type',  " +
          " mv.vehicle_status as 'Status', mv.Check_type as 'Check Type', " +
          " DATE_FORMAT(mv.maintenance_date, '%Y %M %D') as 'Maintenance Date', " +
          " '     Select    ' as '     Select Row     ' " +
            " from maintenance_vehicle as mv " +
            " join vehicle as lv on mv.vehicle_code = lv.vehicle_code " +
            "  where mv.vehicle_status = 'Unchecked'; ", GlobalClass.con);
            GlobalClass.con.Open();
            //GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            DataTable dt1 = new DataTable();
            sql_cmd.Fill(dt1);

            Uncheck_maintanance.ItemsSource = dt1.DefaultView;

            sql_cmd =
          new MySqlDataAdapter("select mv.maintenance_id as 'ID', mv.vehicle_code as 'Vehicle Code', lv.vehicle_type as 'Type',  " +
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



        private void Check_maintanance_selection(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("hello man");
            DataRowView Selected_vehicle = Uncheck_maintanance.SelectedItem as DataRowView;
            Selected_v_index = Selected_vehicle.Row.ItemArray[0].ToString();

        }

        private void Button_Click_View_Vehicle(object sender, RoutedEventArgs e)
        {

            if (Selected_v_index == "")
            {
                MessageBox.Show("You haven't selected any vehicle!");
            }
            else
            {

                ViewMaintenanceVehicle vmv = new ViewMaintenanceVehicle(Selected_v_index);
                vmv.ShowDialog();

            }



        }
    }
}
