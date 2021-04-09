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
using ClosedXML.Excel;
using Lafarge_WPF.Pages;
using MySql.Data.MySqlClient;
using System.Web;


namespace Lafarge_WPF.Pages

{
    /// <summary>
    /// Interaction logic for weekly_report.xaml
    /// </summary>
    public partial class weekly_report : Page
    {

        int latestWeekForV;
        int numOfV;
        int currentWeek=0;
        //string[] allVCode;
        int[] currentVFalseChecks = new int[16];
        int[,] AllFalseCheck;
        List<WeeklyData> wData = new List<WeeklyData>();
        public static DateTime currentDate;
        public static int ScrollThroughWeeks;

        public weekly_report()
        {
            InitializeComponent();
            currentDate = GlobalClass.GetNistTime(); 
            Weekly_date_date.Text = currentDate.ToString();
            LoadData();
            ScrollThroughWeeks = 0;
           
            
            //DateTime dt2 = currentDate.AddDays(-3); //this is how you subtract days 
           
            

        }


        void previousWeek()
        {

            //MessageBox.Show("got here 1");
            GlobalClass.con.Open();
            string LWcommand = "Select dayofweek('" + currentDate.ToString("yyyy-MM-dd") + "');";
            MySqlCommand sql_cmd_LW = new MySqlCommand(LWcommand, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd_LW.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int dayNum = 0;
            if (GlobalClass.sql_dr.HasRows)
            {
                dayNum = GlobalClass.sql_dr.GetInt16(0);
            }
            else
            {
                MessageBox.Show("There was an isuue connecting!");

            }
            //GlobalClass.con.Close();
            GlobalClass.sql_dr.Close();

            //MessageBox.Show("got here 2");

            if (dayNum == 6 || dayNum == 7)
            {
                MessageBox.Show("Today is not a working day!");
                GlobalClass.con.Close();
            }
            else
            {

                DateTime lastWeek = currentDate.AddDays(-(dayNum + 2));


                //numOfV = GlobalOperations.num_of_vehicles();
                /////
                //GlobalClass.con.Open();
                //SELECT COUNT(*) FROM cities;
                DateTime tempdate = lastWeek.AddDays(-5);
                string command_select = "SELECT COUNT(*) FROM vehicle as a " +
                    " inner join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
                    " where b.weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                    " and b.weekly_Date >= '"+ tempdate.ToString("yyyy-MM-dd") +"' ;";
                MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd.ExecuteReader();
                GlobalClass.sql_dr.Read();

                numOfV = GlobalClass.sql_dr.GetInt16(0);
                //GlobalClass.con.Close();
                GlobalClass.sql_dr.Close();
                ///////////////
                ///

                //MessageBox.Show("got here 3");

                if (numOfV > 0)
                {



                    //allVCode = new string[numOfV];
                    AllFalseCheck = new int[numOfV, 16];


                    //
                    //allVCode = GlobalOperations.getAllVehicleCode();


                    int indexx = 0;
                    string[] allVehicles = new string[numOfV];


                    //GlobalClass.con.Open();
                    string cmdtxtt = " select a.vehicle_code from vehicle as a" +
                        " join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
                         " where b.weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                    " and b.weekly_Date >= '" + tempdate.ToString("yyyy-MM-dd") + "' ;";
                    MySqlCommand cmdd = new MySqlCommand(cmdtxtt, GlobalClass.con);
                    GlobalClass.sql_dr = cmdd.ExecuteReader();
                    while (GlobalClass.sql_dr.Read())
                    {
                        allVehicles[indexx] = GlobalClass.sql_dr.GetString(0);
                        if (numOfV != (indexx + 1))
                            indexx += 1;
                    }
                    //GlobalClass.con.Close();

                    GlobalClass.sql_dr.Close();
                    //MessageBox.Show("got here 4");




                    //currentDate = lastWeek;

                    List<WeeklyData> PrevWData = new List<WeeklyData>();

                    for (int i = 0; i < numOfV; i++)
                    {


                        /////////////////////
                        //GlobalClass.con.Open();
                        string command_select_w_i = " SELECT a.weekly_index FROM weekly_reports as a where a.vehicle_code = '" + allVehicles[i] + "' " +
                             " and a.weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                    " and a.weekly_Date >= '" + tempdate.ToString("yyyy-MM-dd") + "' "+
                        " order by a.weekly_index desc limit 1; ";

                        MySqlCommand sql_cmd_w_i = new MySqlCommand(command_select_w_i, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd_w_i.ExecuteReader();
                        GlobalClass.sql_dr.Read();
                        int currentPrevWeek = GlobalClass.sql_dr.GetInt32(0);

                        GlobalClass.sql_dr.Close();

                        //GlobalClass.con.Close();
                        //////////////////////////


                        ///////////
                        //currentVFalseChecks = GlobalOperations.getAllLatestFalseCheck(currentWeek, allVCode[i]);


                        int[] falseCheckList = new int[16];
                        int ii = 0;

                        /*
                        select false_check_rep from weekly_checks_sub where 
                        weekly_index =  2
                        and vehicle_code = 'M44'
                        order by check_rep_date desc ;
                         */


                        //GlobalClass.con.Open();


                        string command_select2 = "select false_check_rep from weekly_checks_sub where " +
                            " weekly_index = " + currentPrevWeek + " and vehicle_code = '" + allVehicles[i] + "' " +
                            " order by check_rep_date desc limit 16 ; ";
                        MySqlCommand sql_cmd2 = new MySqlCommand(command_select2, GlobalClass.con);
                        GlobalClass.sql_dr = sql_cmd2.ExecuteReader();

                        while (GlobalClass.sql_dr.Read())
                        {

                            falseCheckList[ii] = GlobalClass.sql_dr.GetInt32(0);
                            ii += 1;

                        }

                        GlobalClass.sql_dr.Close();
                        //GlobalClass.con.Close();
                        /////////////////////////
                        ///




                        for (int x = 0; x < 16; x++)
                        {
                            AllFalseCheck[i, x] = falseCheckList[x];

                        }



                        PrevWData.Add(new WeeklyData()
                        {
                            v_codee = allVehicles[i],
                            P1 = AllFalseCheck[i, 0],
                            P2 = AllFalseCheck[i, 1],
                            P3 = AllFalseCheck[i, 2],
                            P4 = AllFalseCheck[i, 3],
                            P5 = AllFalseCheck[i, 4],
                            P6 = AllFalseCheck[i, 5],
                            P7 = AllFalseCheck[i, 6],
                            P8 = AllFalseCheck[i, 7],
                            P9 = AllFalseCheck[i, 8],
                            P10 = AllFalseCheck[i, 9],
                            P11 = AllFalseCheck[i, 10],
                            P12 = AllFalseCheck[i, 11],
                            P13 = AllFalseCheck[i, 12],
                            P14 = AllFalseCheck[i, 13],
                            P15 = AllFalseCheck[i, 14],
                            P16 = AllFalseCheck[i, 15],
                            weeklyNote = ""
                        });

                        //MessageBox.Show("got here 5");



                    }
                    weekly_report1.ItemsSource = PrevWData;
                    DataContext = PrevWData;
                    currentDate = lastWeek;
                    Weekly_date_date.Text = currentDate.ToString();
                    GlobalClass.con.Close();
                    ScrollThroughWeeks -= 1;


                }
                else
                {
                    MessageBox.Show("There is no data for Previous week");
                    GlobalClass.con.Close();
                }
            }

        }

        void nextWeek()
        {


            //MessageBox.Show("got here 1");
            GlobalClass.con.Open();
            //string LWcommand = "Select dayofweek('" + currentDate.ToString("yyyy-MM-dd") + "');";
            //MySqlCommand sql_cmd_LW = new MySqlCommand(LWcommand, GlobalClass.con);
            //GlobalClass.sql_dr = sql_cmd_LW.ExecuteReader();
            //GlobalClass.sql_dr.Read();
            //int dayNum = 0;
            /*if (GlobalClass.sql_dr.HasRows)
            {
                dayNum = GlobalClass.sql_dr.GetInt16(0);
            }
            else
            {
                MessageBox.Show("There was an isuue connecting!");

            }
            //GlobalClass.con.Close();
            GlobalClass.sql_dr.Close();*/

            //MessageBox.Show("got here 2");

            DateTime lastWeek = currentDate.AddDays(7);
            DateTime tempDate = lastWeek.AddDays(-5);


            //numOfV = GlobalOperations.num_of_vehicles();
            /////
            //GlobalClass.con.Open();
            //SELECT COUNT(*) FROM cities;
            string command_select = "SELECT COUNT(*) FROM vehicle as a " +
                " inner join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
                " where b.weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                "and b.weekly_Date >=  '"+ tempDate.ToString("yyyy-MM-dd") +"' ;";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();

            numOfV = GlobalClass.sql_dr.GetInt16(0);
            //GlobalClass.con.Close();
            GlobalClass.sql_dr.Close();
            ///////////////
            ///

            //MessageBox.Show("got here 3");

            if (numOfV > 0)
            {



                //allVCode = new string[numOfV];
                AllFalseCheck = new int[numOfV, 16];


                //
                //allVCode = GlobalOperations.getAllVehicleCode();


                int indexx = 0;
                string[] allVehicles = new string[numOfV];


                //GlobalClass.con.Open();

                MySqlCommand cmdd = new MySqlCommand(" select a.vehicle_code from vehicle as a" +
                    " join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
                    " where weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                    "and weekly_Date >=  '"+ tempDate.ToString("yyyy-MM-dd") +"'  ;", GlobalClass.con);
                GlobalClass.sql_dr = cmdd.ExecuteReader();
                while (GlobalClass.sql_dr.Read())
                {
                    allVehicles[indexx] = GlobalClass.sql_dr.GetString(0);
                    if (numOfV != (indexx + 1))
                        indexx += 1;
                }
                //GlobalClass.con.Close();

                GlobalClass.sql_dr.Close();
                //MessageBox.Show("got here 4");




                //currentDate = lastWeek;

                List<WeeklyData> PrevWData = new List<WeeklyData>();

                for (int i = 0; i < numOfV; i++)
                {


                    /////////////////////
                    //GlobalClass.con.Open();
                    string command_select_w_i = " SELECT a.weekly_index FROM weekly_reports as a where a.vehicle_code = '" + allVehicles[i] + "' " +
                        " and weekly_Date <= '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                        "and weekly_Date >=  '"+ tempDate.ToString("yyyy-MM-dd") +"'  " +
                                            " order by weekly_index desc limit 1; ";

                    MySqlCommand sql_cmd_w_i = new MySqlCommand(command_select_w_i, GlobalClass.con);
                    GlobalClass.sql_dr = sql_cmd_w_i.ExecuteReader();
                    GlobalClass.sql_dr.Read();
                    int currentPrevWeek = GlobalClass.sql_dr.GetInt32(0);

                    GlobalClass.sql_dr.Close();

                    //GlobalClass.con.Close();
                    //////////////////////////


                    ///////////
                    //currentVFalseChecks = GlobalOperations.getAllLatestFalseCheck(currentWeek, allVCode[i]);


                    int[] falseCheckList = new int[16];
                    int ii = 0;

                    /*
                    select false_check_rep from weekly_checks_sub where 
                    weekly_index =  2
                    and vehicle_code = 'M44'
                    order by check_rep_date desc ;
                     */


                    //GlobalClass.con.Open();


                    string command_select2 = "select false_check_rep from weekly_checks_sub where " +
                        " weekly_index = " + currentPrevWeek + " and vehicle_code = '" + allVehicles[i] + "' " +
                        " order by check_rep_date desc limit 16 ; ";
                    MySqlCommand sql_cmd2 = new MySqlCommand(command_select2, GlobalClass.con);
                    GlobalClass.sql_dr = sql_cmd2.ExecuteReader();

                    while (GlobalClass.sql_dr.Read())
                    {

                        falseCheckList[i] = GlobalClass.sql_dr.GetInt32(0);
                        ii += 1;

                    }

                    GlobalClass.sql_dr.Close();
                    //GlobalClass.con.Close();
                    /////////////////////////
                    ///




                    for (int x = 0; x < 16; x++)
                    {
                        AllFalseCheck[i, x] = currentVFalseChecks[x];

                    }

                    

                    PrevWData.Add(new WeeklyData()
                    {
                        v_codee = allVehicles[i],
                        P1 = AllFalseCheck[i, 0],
                        P2 = AllFalseCheck[i, 1],
                        P3 = AllFalseCheck[i, 2],
                        P4 = AllFalseCheck[i, 3],
                        P5 = AllFalseCheck[i, 4],
                        P6 = AllFalseCheck[i, 5],
                        P7 = AllFalseCheck[i, 6],
                        P8 = AllFalseCheck[i, 7],
                        P9 = AllFalseCheck[i, 8],
                        P10 = AllFalseCheck[i, 9],
                        P11 = AllFalseCheck[i, 10],
                        P12 = AllFalseCheck[i, 11],
                        P13 = AllFalseCheck[i, 12],
                        P14 = AllFalseCheck[i, 13],
                        P15 = AllFalseCheck[i, 14],
                        P16 = AllFalseCheck[i, 15],
                        weeklyNote = ""
                    });

                    //MessageBox.Show("got here 5");

                    weekly_report1.ItemsSource = PrevWData;
                    DataContext = PrevWData;
                    currentDate = lastWeek;
                    Weekly_date_date.Text = currentDate.ToString();
                    GlobalClass.con.Close();
                    //ScrollThroughWeeks += 1;

                }

            }
            else
            {
                MessageBox.Show("There is no data for next week");
                GlobalClass.con.Close();
            }


        }


        void LoadData()
        {
            /////////////////////////
            GlobalClass.con.Open();
            string LWcommand = "Select dayofweek('" + currentDate.ToString("yyyy-MM-dd") + "');";
            MySqlCommand sql_cmd_LW = new MySqlCommand(LWcommand, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd_LW.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int dayNum = 0;
            if (GlobalClass.sql_dr.HasRows)
            {
                dayNum = GlobalClass.sql_dr.GetInt16(0);
            }
            else
            {
                MessageBox.Show("There was an isuue connecting!");

            }

            GlobalClass.sql_dr.Close();

            DateTime lastWeek = currentDate.AddDays(-dayNum);


            ///////////////////////////
            //numOfV = GlobalOperations.num_of_vehicles();

            //SELECT COUNT(*) FROM cities;
            string command_select = "SELECT COUNT(distinct a.vehicle_code) FROM vehicle as a " +
               " inner join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
               " where b.weekly_Date > '" + lastWeek.ToString("yyyy-MM-dd") + "' ;";
           

            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            numOfV = GlobalClass.sql_dr.GetInt32(0);
            //GlobalClass.con.Close();
            //return num_of_v;
            ////////////
            GlobalClass.sql_dr.Close();


            ///

            AllFalseCheck = new int[numOfV, 16];
            
            //allVCode = GlobalOperations.getAllVehicleCode();


            
            int indexx = 0;
            string[] allVehicles = new string[numOfV];


           // GlobalClass.con.Open();

            MySqlCommand cmdd = new MySqlCommand("SELECT distinct a.vehicle_code FROM vehicle as a " +
               " inner join weekly_reports as b on a.vehicle_code = b.vehicle_code " +
               " where b.weekly_Date > '" + lastWeek.ToString("yyyy-MM-dd") + "' ;", GlobalClass.con);
            GlobalClass.sql_dr = cmdd.ExecuteReader();
            while (GlobalClass.sql_dr.Read())
            {
                allVehicles[indexx] = GlobalClass.sql_dr.GetString(0);
                if (numOfV != (indexx + 1))
                    indexx += 1;
            }

            /////////
            ///
            GlobalClass.sql_dr.Close();


            List<WeeklyData> ThisWData = new();


            for (int i = 0; i < numOfV; i++)
            {


                ////
                //currentWeek = GlobalOperations.GetLastNumber_w_r(allVCode[i]);

                string command_select_w_i = " SELECT a.weekly_index FROM weekly_reports as a where a.vehicle_code = '" + allVehicles[i] + "' " +
                        " and weekly_Date > '" + lastWeek.ToString("yyyy-MM-dd") + "' " +
                                            " order by weekly_index desc limit 1; ";

                MySqlCommand sql_cmd_w_i = new MySqlCommand(command_select_w_i, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd_w_i.ExecuteReader();
                GlobalClass.sql_dr.Read();
                int currentWeekLatest = GlobalClass.sql_dr.GetInt32(0);


                ////
                GlobalClass.sql_dr.Close();

                //currentVFalseChecks = GlobalOperations.getAllLatestFalseCheck(currentWeekLatest, allVCode[i]);

                int[] falseCheckList = new int[16];
                int iii = 0;

                /*
                select false_check_rep from weekly_checks_sub where 
                weekly_index =  2
                and vehicle_code = 'M44'
                order by check_rep_date desc ;
                 */


                //GlobalClass.con.Open();


                string command_select_22 = "select false_check_rep from weekly_checks_sub where " +
                    " weekly_index = " + currentWeekLatest + " and vehicle_code = '" + allVehicles[i] + "' " +
                    " order by check_rep_date desc limit 16 ; ";
                MySqlCommand sql_cmd_22 = new MySqlCommand(command_select_22, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd_22.ExecuteReader();

                while (GlobalClass.sql_dr.Read())
                {
                    falseCheckList[iii] = GlobalClass.sql_dr.GetInt32(0);
                    iii += 1;

                }

                GlobalClass.sql_dr.Close();

                //////

                for (int x = 0; x < 16; x++)
                {
                    AllFalseCheck[i, x] = falseCheckList[x];

                }
               

                ThisWData.Add(new WeeklyData()
                {
                    v_codee = allVehicles[i],
                    P1 = AllFalseCheck[i, 0],
                    P2 = AllFalseCheck[i, 1],
                    P3 = AllFalseCheck[i, 2],
                    P4 = AllFalseCheck[i, 3],
                    P5 = AllFalseCheck[i, 4],
                    P6 = AllFalseCheck[i, 5],
                    P7 = AllFalseCheck[i, 6],
                    P8 = AllFalseCheck[i, 7],
                    P9 = AllFalseCheck[i, 8],
                    P10 = AllFalseCheck[i, 9],
                    P11 = AllFalseCheck[i, 10],
                    P12 = AllFalseCheck[i, 11],
                    P13 = AllFalseCheck[i, 12],
                    P14 = AllFalseCheck[i, 13],
                    P15 = AllFalseCheck[i, 14],
                    P16 = AllFalseCheck[i, 15],
                    weeklyNote = ""
                });
                        
                        

            }
weekly_report1.ItemsSource = ThisWData;
                        DataContext = ThisWData;

GlobalClass.con.Close();
            


        }


        private void weekly_report_Selection(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Goback_btn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.view_report());
        }

        private void Download_btn(object sender, RoutedEventArgs e)
        {

           
            download_buttonn(); 

        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void prev_button_click(object sender, MouseButtonEventArgs e)
        {
            //ScrollThroughWeeks -= 1;
            previousWeek();
        }

        private void nextWeek_button_click(object sender, MouseButtonEventArgs e)
        {
            if (ScrollThroughWeeks == -1)
            {
                currentDate = GlobalClass.GetNistTime();
                LoadData();
                ScrollThroughWeeks += 1;
            }

            else if(ScrollThroughWeeks == 0)
                {
                    MessageBox.Show("There is no data for next week!");
                }
            else
            {
                nextWeek();
                ScrollThroughWeeks += 1;
            }  
             
        }



        void download_buttonn()
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
                worKsheeT.Name = "Weekly Report";

                worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 18]].Merge();
                worKsheeT.Cells[1, 1] = "Weekly Report, " + currentDate.ToString("yyyy-MM-dd");
                worKsheeT.Cells.Font.Size = 15;


            

                for (int i = 1; i < weekly_report1.Columns.Count + 1; i++)
                {
                    worKsheeT.Cells[2, i] = weekly_report1.Columns[i - 1].Header.ToString();
                }

                for (int i = 0; i < weekly_report1.Items.Count; i++)
                {

                    worKsheeT.Cells[i + 3, 1] = wData[i].v_codee;
                    worKsheeT.Cells[i + 3, 2] = wData[i].P1;
                    worKsheeT.Cells[i + 3, 3] = wData[i].P2;
                    worKsheeT.Cells[i + 3, 4] = wData[i].P3;
                    worKsheeT.Cells[i + 3, 5] = wData[i].P4;
                    worKsheeT.Cells[i + 3, 6] = wData[i].P5;
                    worKsheeT.Cells[i + 3, 7] = wData[i].P6;
                    worKsheeT.Cells[i + 3, 8] = wData[i].P7;
                    worKsheeT.Cells[i + 3, 9] = wData[i].P8;
                    worKsheeT.Cells[i + 3, 10] = wData[i].P9;
                    worKsheeT.Cells[i + 3, 11] = wData[i].P10;
                    worKsheeT.Cells[i + 3, 12] = wData[i].P11;
                    worKsheeT.Cells[i + 3, 13] = wData[i].P12;
                    worKsheeT.Cells[i + 3, 14] = wData[i].P13;
                    worKsheeT.Cells[i + 3, 15] = wData[i].P14;
                    worKsheeT.Cells[i + 3, 16] = wData[i].P15;
                    worKsheeT.Cells[i + 3, 17] = wData[i].P16;
                    worKsheeT.Cells[i + 3, 18] = wData[i].weeklyNote;
                    worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                }


                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[weekly_report1.Items.Count+2, weekly_report1.Columns.Count]];
                celLrangE.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                celLrangE.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                celLrangE.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, weekly_report1.Columns.Count]];

                //worKbooK.SaveAs();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog() { };


                dlg.ShowDialog();
                string folderPath = "";

                    if (dlg.CheckPathExists)
                    {
                        folderPath =  ""+dlg.FileName +"-"+currentDate.ToString("yyyy-MM-dd") +".xlsx";
                    }
                


                worKbooK.SaveAs(folderPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, (Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange), Type.Missing, Type.Missing, Type.Missing);
                //"C:\\Users\\Unimaginable\\Documents\\excell\\outputt.xls"
                worKbooK.Close();
                excel.Quit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }
        }
      
      




    }
}
