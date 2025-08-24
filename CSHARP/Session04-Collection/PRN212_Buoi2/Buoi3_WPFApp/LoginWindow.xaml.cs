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
using Buoi2_Service;

namespace Buoi3_WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginServices loginServices;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            loginServices = new();
            string username = txtUsername.Text;
            string password = pwdPassword.Password;
            var account = loginServices.Login(username, password);
            if (account != null)
            {
                MainWindow main = new MainWindow();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Login error!!!", "Login.....", MessageBoxButton.OK);
            }

        }
    }
}
