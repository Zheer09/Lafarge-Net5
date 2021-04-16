using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Input;

namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Monthly_report.xaml
    /// </summary>
    public partial class Monthly_report : Page
    {

        public static DateTime currentDate;
        DateTime startDate, endDate;
        List<monthlyData> MonthlyStore = new List<monthlyData>();
        int scrollTracker = 0;


        public Monthly_report()
        {
            InitializeComponent();
            currentDate = GlobalClass.GetNistTime();
            monthly_date_text.Text = currentDate.ToString("MMMM");
            refreshData();

        }


        void refreshData()
        {
            int month_num = Int32.Parse( currentDate.ToString("dd") );
            DateTime begginingOfMonth = currentDate.AddDays(-month_num);
            GlobalClass.con.Open();
            MySqlCommand da = new MySqlCommand(" select distinct vehicle_code, 50hr_w1, w1_status,  50hr_w2, w2_status,  50hr_w3, w3_status, " +
                "  50hr_w4, w4_status, 300hr_m, monthly_status, workingHours from monthly_report where monthly_date > '" + begginingOfMonth.ToString("yyyy-MM-dd") + "'; ", GlobalClass.con);
            GlobalClass.sql_dr = da.ExecuteReader();
            string vehicle_C = "";
            string assett = "";
            string[] monthy_data = new string[10];
            while (GlobalClass.sql_dr.Read())
            {
                vehicle_C = GlobalClass.sql_dr.GetString(0);
                if(vehicle_C[0] == 'L')
                {
                    assett = "Loader";
                }else if (vehicle_C[0] == 'M')
                {
                    assett = "Mixer";
                }
                else if (vehicle_C[0] == 'C')
                {
                    assett = "Concrete Pump";
                }
                else
                {
                    assett = "Unknown!";
                }

                monthy_data = new string[10];

                for(int i = 0; i < 10; i++)
                {
                    if (!(GlobalClass.sql_dr.IsDBNull(i+1)))
                    {
                        monthy_data[i] = GlobalClass.sql_dr.GetString(i+1);
                    }
                }
                

                MonthlyStore.Add(new monthlyData()
                {

                    vehicle_code = GlobalClass.sql_dr.GetString(0),
                    asset = assett,
                    hr50_w1 = monthy_data[0],
                    w1_status = monthy_data[1],
                    hr50_w2 = monthy_data[2],
                    w2_status = monthy_data[3],
                    hr50_w3 = monthy_data[4],
                    w3_status = monthy_data[5],
                    hr50_w4 = monthy_data[6],
                    w4_status = monthy_data[7],
                    hr300_m = monthy_data[8],
                    monthly_status = monthy_data[9],
                    workingHours = GlobalClass.sql_dr.GetFloat(11)

                }) ; 
            }

            Monthly_report1.ItemsSource = MonthlyStore;


            GlobalClass.con.Close();
        }


        void nextMonth()
        {

            

        }

        void previousMonth()
        {
            int currentDay = Convert.ToInt32(currentDate.ToString("dd"));

            endDate = currentDate.AddDays(-currentDay);

            int currentYear = Convert.ToInt32(endDate.ToString("yyyy"));
            int currentMonth = Convert.ToInt32(endDate.ToString("MM"));

            startDate = new DateTime(currentYear, currentMonth, 1); // these have been tested perfectly working.

            GlobalClass.con.Open();

            MySqlCommand da = new MySqlCommand(" select distinct vehicle_code, 50hr_w1, w1_status,  50hr_w2, w2_status,  50hr_w3, w3_status, " +
                "  50hr_w4, w4_status, 300hr_m, monthly_status, workingHours from monthly_report where monthly_date >= '" + startDate.ToString("yyyy-MM-dd") +
                "' and monthly_date <= '"+ endDate.ToString("yyyy-MM-dd") +"' ; ", GlobalClass.con);
            GlobalClass.sql_dr = da.ExecuteReader();
            string vehicle_C = "";
            string assett = "";
            string[] monthy_data = new string[10];

            if (GlobalClass.sql_dr.HasRows)
            {
                 while (GlobalClass.sql_dr.Read())
                {
                    vehicle_C = GlobalClass.sql_dr.GetString(0);
                    if (vehicle_C[0] == 'L')
                    {
                        assett = "Loader";
                    }
                    else if (vehicle_C[0] == 'M')
                    {
                        assett = "Mixer";
                    }
                    else if (vehicle_C[0] == 'C')
                    {
                        assett = "Concrete Pump";
                    }
                    else
                    {
                        assett = "Unknown!";
                    }

                    monthy_data = new string[10];

                    for (int i = 0; i < 10; i++)
                    {
                        if (!(GlobalClass.sql_dr.IsDBNull(i + 1)))
                        {
                            monthy_data[i] = GlobalClass.sql_dr.GetString(i + 1);
                        }
                    }

                    MonthlyStore = new List<monthlyData>();

                    MonthlyStore.Add(new monthlyData()
                    {

                        vehicle_code = GlobalClass.sql_dr.GetString(0),
                        asset = assett,
                        hr50_w1 = monthy_data[0],
                        w1_status = monthy_data[1],
                        hr50_w2 = monthy_data[2],
                        w2_status = monthy_data[3],
                        hr50_w3 = monthy_data[4],
                        w3_status = monthy_data[5],
                        hr50_w4 = monthy_data[6],
                        w4_status = monthy_data[7],
                        hr300_m = monthy_data[8],
                        monthly_status = monthy_data[9],
                        workingHours = GlobalClass.sql_dr.GetFloat(11)

                    });
                }

                Monthly_report1.ItemsSource = MonthlyStore;
                monthly_date_text.Text = startDate.ToString("MMMM");
                currentDate = startDate;
                GlobalClass.con.Close();
            }
            else
            {
                MessageBox.Show("There is no data for previous month!");
            }

            GlobalClass.con.Close();

        }

        private void Monthly_report_selction(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Goback_btn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.view_report());
        }

        private void Download_btn(object sender, RoutedEventArgs e)
        {

        }

        private void Weekly_date_date_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void prev_button_Click(object sender, RoutedEventArgs e)
        {
            previousMonth();
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
