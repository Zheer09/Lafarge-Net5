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
    /// Interaction logic for Account_info_Page.xaml
    /// </summary>
    public partial class Account_info_Page : Page
    {
        public Account_info_Page()
        {
            InitializeComponent();

            SelectAccount myAccount = new SelectAccount();
            myAccount = GlobalOperations.getAccountData(GlobalClass.Account_username);

            username_label.Text = myAccount.accUsername;
            full_label.Text = myAccount.accFullName;
            phone_label.Text = myAccount.accPhoneNum;
            email_abel.Text = myAccount.accEmail;
            role_label.Text = myAccount.accUserRole;


        }
    }
}
