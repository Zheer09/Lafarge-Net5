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
        List<WeeklyData> VData = new List<WeeklyData>();


        public ViewMaintenanceVehicle(string maintenanceVehicleIndex, string weekly_id)
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
                //mv.maintenance_id = GlobalClass.sql_dr.GetString(0);
                //w_ii.Content = GlobalClass.sql_dr.GetInt32(1);
                mv.vehicle_code = GlobalClass.sql_dr.GetString(2);
                mv.vehicle_status = GlobalClass.sql_dr.GetString(3);
                mv.Check_type = GlobalClass.sql_dr.GetString(4);
                mv.maintenance_date = GlobalClass.sql_dr.GetDateTime(5) ;

            }

            

            //m_iid.Content = mv.maintenance_id;
            v_cc.Content = mv.vehicle_code;
            ch_t.Content = mv.Check_type;
            v_ss.Content = mv.vehicle_status;
            m_dd.Content = mv.maintenance_date.ToString();

            ////////////

            GlobalClass.sql_dr.Close();

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
                " weekly_index = " + weekly_id + " and vehicle_code = '" + mv.vehicle_code + "' " +
                " order by check_rep_date desc limit 16 ; ";
            MySqlCommand sql_cmd2 = new MySqlCommand(command_select2, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd2.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {

                AllFalseCheck[ii] = GlobalClass.sql_dr.GetInt32(0);
                ii += 1;

            }

            GlobalClass.con.Close();

            VData.Add(new WeeklyData()
                        {
                            v_codee = mv.vehicle_code,
                            P1 = AllFalseCheck[0],
                            P2 = AllFalseCheck[1],
                            P3 = AllFalseCheck[ 2],
                            P4 = AllFalseCheck[3],
                            P5 = AllFalseCheck[ 4],
                            P6 = AllFalseCheck[ 5],
                            P7 = AllFalseCheck[ 6],
                            P8 = AllFalseCheck[ 7],
                            P9 = AllFalseCheck[ 8],
                            P10 = AllFalseCheck[ 9],
                            P11 = AllFalseCheck[ 10],
                            P12 = AllFalseCheck[ 11],
                            P13 = AllFalseCheck[ 12],
                            P14 = AllFalseCheck[ 13],
                            P15 = AllFalseCheck[ 14],
                            P16 = AllFalseCheck[ 15],
                            weeklyNote = ""
                        });

            m_v_grid.ItemsSource = VData;

            for (int i = 0; i < 16; i++)
            {
                if (AllFalseCheck[i] < 5)
                {
                    m_v_grid.Columns[i+1].Visibility = Visibility.Hidden;
                }
            }
        }


      /*  void fillGrid()
        {
            //WeeklyData VData = new WeeklyData();

        }*/


    }
}
