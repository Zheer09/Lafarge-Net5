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
using System.IO;

// I am drinking maksiki right now zheer be to naxosh hahahaha
// check this:
// https://stackoverflow.com/questions/6359848/wpf-loading-spinner 


namespace Lafarge_WPF
{
    ///  <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            if (GlobalClass.CheckForInternetConnection())
            {
                // internet connection is fine
            }
            else
            {
                MessageBox.Show("Warning: you are not connected to internet!");
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }
        }

        private bool login_check(String user_name, String pass)
        {



            MySqlCommand sql_cmd = new MySqlCommand("select username from user_account where username='" + user_name + "'", GlobalClass.con);

            try
            {
                GlobalClass.con.Open();
                GlobalClass.sql_dr = sql_cmd.ExecuteReader();


                if (GlobalClass.sql_dr.HasRows)
                {

                    GlobalClass.sql_dr.Close();
                    sql_cmd = new MySqlCommand("select password from user_account where username = '" + user_name + "'", GlobalClass.con);
                    GlobalClass.sql_dr = sql_cmd.ExecuteReader();
                    GlobalClass.sql_dr.Read();

                    if (GlobalClass.sql_dr.GetString(0) == pass)
                    {
                        //MessageBox.Show("Login successful!");
                        GlobalClass.Account_username = user_name;
                        GlobalClass.con.Close();
                        return true;
                    }
                    else
                    {

                        GlobalClass.con.Close();
                        Wrong_usrpwd.Text = "Password is incorrect for " + user_name + "!";

                        return false;
                    }

                }
                else
                {
                    // if the database doesn't have the username that the user has entered.

                    Wrong_usrpwd.Text = "Username or Password is incorrect!";
                    GlobalClass.con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Wrong_usrpwd.Text = ex.Message;
                MessageBox.Show("Error! Check your Internet.");
            }




            // this part will never be executed, just in case something wrong happens it might help.
            //GlobalClass.con.Close();
            return false;
        }


        // this event happens when you press the login button, zheer forgot to name the button lol
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String U_Name = Username.Text;
            String Pass_Word = inputPassword.Password.ToString();
            Wrong_usrpwd.Text = "";

            if (GlobalClass.CheckForInternetConnection())
            {



                GlobalClass.setCon();
                GlobalClass.login_status = login_check(U_Name, Pass_Word);



                if (GlobalClass.login_status)
                {
                    //MessageBox.Show("Login successful for " + GlobalClass.Account_username);
                    this.Hide();
                    HomePage home_page = new HomePage();
                    home_page.ShowDialog();

                }
                else
                {
                    // do nothing... 

                }

            }
            else
            {
                MessageBox.Show("Warning: you are not connected to internet!");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Close_btn(object sender, MouseButtonEventArgs e)
        {
            System.Environment.Exit(1);

        }

        private void MiniBtn(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
