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
    /// Interaction logic for SearchResultWindowSub.xaml
    /// </summary>
    public partial class SearchResultWindowSub : Window
    {

        List<MaintenanceFalseCheck> tempData = new();

        public SearchResultWindowSub(int report_id)
        {
            InitializeComponent();
            RefreshData(report_id);
        }

        void RefreshData(int reportID)
        {
            /*false_check_rep*/

            tempData = new();
            string[] checkNames = new string[16];

            for (int i = 0; i < 16; i++)
            {

                checkNames[i] = "check " + (i + 1);

            }

            GlobalClass.con.Open();

            int x = 0;

            MySqlCommand selectFalse = new MySqlCommand(" select false_check_rep from maintenance_report_sub where report_id = " + reportID +
                " order by check_rep_index asc; ", GlobalClass.con);

            GlobalClass.sql_dr = selectFalse.ExecuteReader();

            if (GlobalClass.sql_dr.HasRows)
            {

                while (GlobalClass.sql_dr.Read())
                {

                    tempData.Add(
                        new MaintenanceFalseCheck
                        {
                            checkName = checkNames[x],
                            falseCheckIntRep = GlobalClass.sql_dr.GetInt32(0)
                        }
                        );
                    x++;
                }

            }

            resultChecks_grid.ItemsSource = tempData;



            GlobalClass.con.Close();


        }


    }
}
