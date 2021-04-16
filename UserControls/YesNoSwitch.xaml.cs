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

namespace Lafarge_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for YesNoSwitch.xaml
    /// </summary>
    public partial class YesNoSwitch : UserControl
    {
        public static readonly DependencyProperty TrueBrushProperty = DependencyProperty.Register("TrueBrush", typeof(object), typeof(YesNoSwitch), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty FalseBrushProperty = DependencyProperty.Register("FalseBrush", typeof(Brush), typeof(YesNoSwitch), new PropertyMetadata(default(Brush)));

        public YesNoSwitch()
        {
            InitializeComponent();
        }

        public Brush TrueBrush
        {
            get => (Brush)GetValue(TrueBrushProperty);
            set => SetValue(TrueBrushProperty, value);
        }

        public Brush FalseBrush
        {
            get => (Brush)GetValue(FalseBrushProperty);
            set => SetValue(FalseBrushProperty, value);
        }

        public event EventHandler YesButtonChecked;
        public event EventHandler NoButtonChecked;
        private void YesButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (YesButton.IsChecked != null && (bool)YesButton.IsChecked)
                NoButton.IsChecked = false;
            YesButtonChecked?.Invoke(sender, e);
        }
        private void NoButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (NoButton.IsChecked != null && (bool)NoButton.IsChecked)
                YesButton.IsChecked = false;
            NoButtonChecked?.Invoke(sender, e);
        }
    }
}
