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

namespace Policy_Renewal
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (txtPasswordBox.Password.ToString() == "0700" )
            {
                var win = new MainWindow();
                win.Owner = this;
                win.Height = 700.967;
                win.Width = 1160.154;
                win.Show();
                Visibility = Visibility.Visible;
            }

            else
            {
                MessageBox.Show("Wrong PIN. Please enter correct pin", "Error");
            }
        }
    }
}
