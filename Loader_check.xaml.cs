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

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {


        }

    }
}
