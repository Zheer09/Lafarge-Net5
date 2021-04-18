using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SearchResult.xaml
    /// </summary>
    public partial class SearchResult : Window
    {

        string vehicle_code;
        List<MaintenanceReportData> tempData = new();
        int Vehicle_report_id;
        int ReportIDMan = 0;

        

        public SearchResult(string V_Code)
        {
            InitializeComponent();
            vehicle_code = V_Code;
            getVehicleData();
            Vehicle_report_id = 0;
            
            


        }


        void getVehicleData()
        {

            float workingHour = 0;

            GlobalClass.con.Open();

            MySqlCommand SQLCMD = new MySqlCommand("select working_hour from vehicle_property " +
            " where vehicle_code = '"+ vehicle_code +"' order by property_date desc limit 1; " , GlobalClass.con);

            GlobalClass.sql_dr = SQLCMD.ExecuteReader();

            GlobalClass.sql_dr.Read();
            if (GlobalClass.sql_dr.HasRows)
            {
                workingHour = GlobalClass.sql_dr.GetFloat(0);
            }

            workingHoursLabel.Text = workingHour + " Hours";
            vehiceCodeLabel.Text = vehicle_code;


            GlobalClass.sql_dr.Close();

            
            /*SELECT * FROM lafarge.maintenance_report;*/
            bool isThereData = false;
            tempData = new();

            MySqlCommand SQLCMD2 = new MySqlCommand("SELECT * FROM maintenance_report where vehicle_code = '" + vehicle_code + "' ;", GlobalClass.con);

            GlobalClass.sql_dr = SQLCMD2.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                if (GlobalClass.sql_dr.HasRows) {
                    tempData.Add(new MaintenanceReportData
                    {
                        report_id = GlobalClass.sql_dr.GetInt32(0),
                        check_type = GlobalClass.sql_dr.GetString(1),
                        vehicle_status = GlobalClass.sql_dr.GetString(2),
                        maintenance_date = GlobalClass.sql_dr.GetString(3),
                        vehicle_code = GlobalClass.sql_dr.GetString(4)
                    }
                    
                        );

                    ReportIDMan = GlobalClass.sql_dr.GetInt32(0);
                    isThereData = true;
                }
            }

            resultMaintenance_grid.ItemsSource = tempData;
            if (!isThereData)
            {
                resultMaintenance_grid.Visibility = Visibility.Hidden;
            }

            GlobalClass.con.Close();

        }


        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        public void doubleClickRow(object sender, MouseButtonEventArgs e)
        {
            if (resultMaintenance_grid.SelectedItem == null)
                return;

            Vehicle_report_id = ((dynamic)resultMaintenance_grid.SelectedItem).report_id;




            if (Vehicle_report_id == 0)
            {
                MessageBox.Show("You haven't selected any row!");
            }
            else 
            {


                SearchResultWindowSub hama = new SearchResultWindowSub(ReportIDMan);
                hama.ShowDialog();
                
                

            }
        }
    }
}
