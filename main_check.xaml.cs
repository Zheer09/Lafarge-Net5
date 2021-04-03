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
            MySqlDataAdapter sql_cmd = new MySqlDataAdapter("select * from maintenance_vehicle", GlobalClass.con);
            GlobalClass.con.Open();
            //GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            DataTable dt1 = new DataTable("maintenance_vehicle");
            sql_cmd.Fill(dt1);

            Check_maintanance.ItemsSource = dt1.DefaultView;
            GlobalClass.con.Close();


        }

        private void Check_maintanance_selection(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
