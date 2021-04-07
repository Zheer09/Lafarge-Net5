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
        string[] allVCode;
        int[] currentVFalseChecks = new int[16];
        int[,] AllFalseCheck;
        List<WeeklyData> wData = new List<WeeklyData>();

        public weekly_report()
        {
            InitializeComponent();
            LoadData();
           

        }


        void LoadData()
        {
            numOfV = GlobalOperations.num_of_vehicles();
            allVCode = new string[numOfV];
            AllFalseCheck = new int[numOfV, 16];

            allVCode = GlobalOperations.getAllVehicleCode();

            for (int i = 0; i < numOfV; i++)
            {

                currentWeek = GlobalOperations.GetLastNumber_w_r(allVCode[i]);
                currentVFalseChecks = GlobalOperations.getAllLatestFalseCheck(currentWeek, allVCode[i]);

                for (int x = 0; x < 16; x++)
                {
                    AllFalseCheck[i, x] = currentVFalseChecks[x];

                }


                wData.Add(new WeeklyData()
                {
                    v_codee = allVCode[i],
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



            weekly_report1.ItemsSource = wData;
            DataContext = wData;
            MessageBox.Show(wData[0].v_codee);
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
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog() { Filter ="Excel Workbook|*.xlsx" };
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        workbook.Worksheets.Add();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
