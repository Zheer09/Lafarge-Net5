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

namespace Lafarge_WPF.Pages
{
    /// <summary>
    /// Interaction logic for search.xaml
    /// </summary>
    public partial class search : Page
    {
        public search()
        {
            InitializeComponent();
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

            if (GlobalOperations.doesVehicleExist(keyWord))
            {
                MessageBox.Show("Vehicle " + keyWord + " exists.");
            }
            else
            {
                MessageBox.Show(keyWord + " does not exist!");
            }





        }

        private void OnPreviewKeyDown2(object sender, KeyEventArgs e)
        {
            OnPreviewKeyDown(e);
        }
    }
}
