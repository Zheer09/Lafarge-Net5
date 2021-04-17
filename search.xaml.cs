using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data;

namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for search.xaml
    /// </summary>
    public partial class search : Page
    {


        List<SelectVehicle> myVehicle = new();
        public static string selectedVehicle;


        public search()
        {
            InitializeComponent();
            selectedVehicle = "";
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if (e.Key == Key.OemQuotes)
            {
                e.Handled = true;
            }
           
            base.OnPreviewKeyDown(e);
        }

        private void find_search_Click(object sender, RoutedEventArgs e)
        {

            string keyWord = search_box.Text;
            keyWord = keyWord.ToUpper();

            if(keyWord == "ALL")
            {

                myVehicle = new();
                GlobalClass.con.Open();
                string command_select = "SELECT * FROM vehicle;";
                MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd.ExecuteReader();

                while (GlobalClass.sql_dr.Read())
                {

                    myVehicle.Add(new SelectVehicle()
                    {

                        vehicle_code = GlobalClass.sql_dr.GetString(0),
                        vehicle_type = GlobalClass.sql_dr.GetString(1),
                        batch_plant = GlobalClass.sql_dr.GetString(2)

                    });

                }


                search_grid.ItemsSource = myVehicle;


                GlobalClass.con.Close();

            }
            else if (GlobalOperations.doesVehicleExist(keyWord))
            {
                myVehicle = new();
                GlobalClass.con.Open();
                string command_select = "SELECT vehicle_code, vehicle_type, batch_plant FROM vehicle where vehicle_code = '" + keyWord + "';";
                MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd.ExecuteReader();

                while (GlobalClass.sql_dr.Read())
                {

                    myVehicle.Add(new SelectVehicle()
                    {

                        vehicle_code = GlobalClass.sql_dr.GetString(0),
                        vehicle_type = GlobalClass.sql_dr.GetString(1),
                        batch_plant = GlobalClass.sql_dr.GetString(2)

                    });

                }

                
                search_grid.ItemsSource = myVehicle;
               

                GlobalClass.con.Close();

            }
            else
            {
                MessageBox.Show(keyWord + " does not exist!");
            }





        }

        private void OnPreviewKeyDown2(object sender, KeyEventArgs e)
        {
            OnPreviewKeyDown(e);
            if (e.Key == Key.Return)
                {
                find_search_Click(sender, e);
                }
        }

        private void doubleClickRow(object sender, MouseButtonEventArgs e)
        {
            if (search_grid.SelectedItem == null)
                return;

             selectedVehicle = ((dynamic)search_grid.SelectedItem).vehicle_code;
            

            

            if (selectedVehicle == "")
            {
                MessageBox.Show("You haven't selected any Vehicle!");
            }
            else
            {
                SearchResult sr = new SearchResult(selectedVehicle);
                sr.ShowDialog();
            }
        }

        

       
    }
}
