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

namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            Main.Content = new Pages.vehicle();
            Account_btn.Content = GlobalClass.Account_username;
            //MessageBox.Show(System.Windows.Media.RenderCapability.Tier.ToString() );
            MaxHeight = SystemParameters.WorkArea.Height;
            MaxWidth = SystemParameters.WorkArea.Width;


        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutBt_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.Account_username = "";
            GlobalClass.login_status = false;

            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();

        }

        private void vehicle_button1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.vehicle();
        }

        private void ViewReport_button2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.view_report();
        }

        private void MainCheck_button3(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.main_check();
        }

        private void Search_button4(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.search();
        }

        private void Minibtn(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Max_Btn(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized
                         ? WindowState.Normal
                         : WindowState.Maximized;
        }

        private void Close_bt(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Account_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Account_info_Page();

        }


    }
}
