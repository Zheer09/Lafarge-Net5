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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for ViewMaintenanceVehicle.xaml
    /// </summary>
    public partial class ViewMaintenanceVehicle : Window
    {

        SelectMaintenanceVehicle mv = new SelectMaintenanceVehicle();



        public ViewMaintenanceVehicle(string maintenanceVehicleIndex)
        {
            InitializeComponent();

            GlobalClass.con.Open();
 
                string command_select = "select mv.maintenance_id, mv.weekly_index, mv.vehicle_code,  " +
          " mv.vehicle_status , mv.Check_type, " +
          " mv.maintenance_date " +
         
            " from maintenance_vehicle as mv " +
            " join vehicle as lv on mv.vehicle_code = lv.vehicle_code " +
            "  where mv.maintenance_id = "+ maintenanceVehicleIndex +" ; ";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                mv.maintenance_id = GlobalClass.sql_dr.GetString(0);
                w_ii.Content = GlobalClass.sql_dr.GetInt32(1);
                mv.vehicle_code = GlobalClass.sql_dr.GetString(2);
                mv.vehicle_status = GlobalClass.sql_dr.GetString(3);
                mv.Check_type = GlobalClass.sql_dr.GetString(4);
                mv.maintenance_date = GlobalClass.sql_dr.GetDateTime(5) ;

            }

            GlobalClass.con.Close();

            m_iid.Content = mv.maintenance_id;
            v_cc.Content = mv.vehicle_code;
            ch_t.Content = mv.Check_type;
            v_ss.Content = mv.vehicle_status;
            m_dd.Content = mv.maintenance_date.ToString();
            


        }
    }
}
