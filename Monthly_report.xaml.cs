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
        public static DateTime startDate, endDate;
        List<monthlyData> MonthlyStore = new();
        public static int scrollTracker = 0;


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

            int startMonth = Convert.ToInt32( currentDate.ToString("MM") );
            int startYear = Convert.ToInt32( currentDate.ToString("yyyy") );
            MonthlyStore = new List<monthlyData>();

            if (startMonth == 12)
            {
                startYear += 1;
                startMonth = 1;
            }
            else
            {
                startMonth += 1;
            }
            startDate = new DateTime(startYear, startMonth, 1);
            endDate = new DateTime(startYear, (startMonth + 1), 1);



            GlobalClass.con.Open();

            MySqlCommand da = new MySqlCommand(" select distinct vehicle_code, 50hr_w1, w1_status,  50hr_w2, w2_status,  50hr_w3, w3_status, " +
                "  50hr_w4, w4_status, 300hr_m, monthly_status, workingHours from monthly_report where monthly_date >= '" + startDate.ToString("yyyy-MM-dd") +
                "' and monthly_date < '" + endDate.ToString("yyyy-MM-dd") + "' ; ", GlobalClass.con);
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
                scrollTracker += 1;

            }
            else
            {
                Monthly_report1.ItemsSource = null;
                MessageBox.Show("There is no data for next month!");
                monthly_date_text.Text = startDate.ToString("MMMM");
                currentDate = startDate;
                scrollTracker -= 1;
            }

            GlobalClass.con.Close();

        }

        void previousMonth()
        {
            int currentDay = Convert.ToInt32(currentDate.ToString("dd"));

            endDate = currentDate.AddDays(-currentDay);

            int currentYear = Convert.ToInt32(endDate.ToString("yyyy"));
            int currentMonth = Convert.ToInt32(endDate.ToString("MM"));

            startDate = new DateTime(currentYear, currentMonth, 1); // these have been tested perfectly working.

            MonthlyStore = new List<monthlyData>();

            GlobalClass.con.Open();

            MySqlCommand da = new MySqlCommand(" select distinct vehicle_code, 50hr_w1, w1_status,  50hr_w2, w2_status,  50hr_w3, w3_status, " +
                "  50hr_w4, w4_status, 300hr_m, monthly_status, workingHours from monthly_report where monthly_date >= '" + startDate.ToString("yyyy-MM-dd") +
                "' and monthly_date <= '"+ endDate.ToString("yyyy-MM-dd") +"' ; ", GlobalClass.con);
            GlobalClass.sql_dr = da.ExecuteReader();
            string vehicle_C = "";
            string[] monthy_data = new string[10];

            if (GlobalClass.sql_dr.HasRows)
            {
                 while (GlobalClass.sql_dr.Read())
                {
                    vehicle_C = GlobalClass.sql_dr.GetString(0);
                    string assett;
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
                scrollTracker -= 1;
            }
            else
            {
                MessageBox.Show("There is no data for previous month!");
                monthly_date_text.Text = startDate.ToString("MMMM");
                currentDate = startDate;
                scrollTracker -= 1;
                Monthly_report1.ItemsSource = null;
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




            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
            Microsoft.Office.Interop.Excel.Range celLrangE;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);


                worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "Monthly Report";

                worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 13]].Merge();
                worKsheeT.Cells[1, 1] = "Monthly Report, " + currentDate.ToString("yyyy-MMMM");
                worKsheeT.Cells.Font.Size = 15;




                for (int i = 1; i < Monthly_report1.Columns.Count + 1; i++)
                {
                    worKsheeT.Cells[2, i] = Monthly_report1.Columns[i - 1].Header.ToString();
                }

                for (int i = 0; i < Monthly_report1.Items.Count; i++)
                {

                    worKsheeT.Cells[i + 3, 1] = MonthlyStore[i].vehicle_code;
                    worKsheeT.Cells[i + 3, 2] = MonthlyStore[i].asset;
                    worKsheeT.Cells[i + 3, 3] = MonthlyStore[i].hr50_w1;
                    worKsheeT.Cells[i + 3, 4] = MonthlyStore[i].w1_status;
                    worKsheeT.Cells[i + 3, 5] = MonthlyStore[i].hr50_w2;
                    worKsheeT.Cells[i + 3, 6] = MonthlyStore[i].w2_status;
                    worKsheeT.Cells[i + 3, 7] = MonthlyStore[i].hr50_w3;
                    worKsheeT.Cells[i + 3, 8] = MonthlyStore[i].w3_status;
                    worKsheeT.Cells[i + 3, 9] = MonthlyStore[i].hr50_w4;
                    worKsheeT.Cells[i + 3, 10] = MonthlyStore[i].w4_status;
                    worKsheeT.Cells[i + 3, 11] = MonthlyStore[i].hr300_m;
                    worKsheeT.Cells[i + 3, 12] = MonthlyStore[i].monthly_status;
                    worKsheeT.Cells[i + 3, 13] = MonthlyStore[i].workingHours;
                    worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                }


                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[Monthly_report1.Items.Count + 2, Monthly_report1.Columns.Count]];
                celLrangE.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;

                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                celLrangE.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                celLrangE.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, Monthly_report1.Columns.Count]];

                //worKbooK.SaveAs();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog() { };


                dlg.ShowDialog();
                string folderPath = "";

                if (dlg.CheckPathExists)
                {
                    folderPath = "" + dlg.FileName + "-" + currentDate.ToString("yyyy-MMMM") + ".xlsx";
                }



                worKbooK.SaveAs(folderPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, (Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange), Type.Missing, Type.Missing, Type.Missing);
                //"C:\\Users\\Unimaginable\\Documents\\excell\\outputt.xls"
                worKbooK.Close();
                excel.Quit();

                if(dlg.FileName != "")
                {
                    MessageBox.Show("Successfully created the Excel file!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There was a problem during the creation of Excel file!");

            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }



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
            nextMonth();
        }
    }
}
