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

namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for main_check.xaml
    /// </summary>
    public partial class main_check : Page
    {
        public main_check()
        {
            InitializeComponent();

            MySqlDataAdapter sql_cmd =
          new MySqlDataAdapter("select mv.vehicle_code as 'Vehicle Code', v.vehicle_type as 'Type', v.batch_plant as 'Batch Plant', "
          + "vp.working_hour as 'Working Hour', mv.vehicle_status as 'Status', "
          + "DATE_FORMAT(mv.maintenance_date, '%Y %M %D') as 'Maintenance Date' from maintenance_vehicle as mv join vehicle as v on mv.vehicle_code = v.vehicle_code "
          + "left join vehicle_property as vp on v.vehicle_code = vp.vehicle_code ; ", GlobalClass.con);
            GlobalClass.con.Open();
            //GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            DataTable dt1 = new DataTable();
            sql_cmd.Fill(dt1);

            Check_maintanance.ItemsSource = dt1.DefaultView;
            GlobalClass.con.Close();


        }

        private void Check_maintanance_selection(object sender, SelectionChangedEventArgs e)
        {

           
        }
    }
}
