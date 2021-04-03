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
using Lafarge_WPF.Pages;


namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for Loader_check.xaml
    /// </summary>
    public partial class Loader_check : Page
    {
        public Loader_check()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DateTime_lable.Text = GlobalClass.GetNistTime().ToString("dd MMMM yyyy");
            //MessageBox.Show(GlobalClass.GetNistTime().ToString("dd MMMM yyyy"));
        }

        

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Goback_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.vehicle());
        }



        // this function checks if every check has been selected and if the required textboxes are filled.
        private bool validateSubmit()
        {

            // code...


            return false;
        }






        // MAIN FUNCTION
        // this is where everything happens man.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {





        }
    }
}
