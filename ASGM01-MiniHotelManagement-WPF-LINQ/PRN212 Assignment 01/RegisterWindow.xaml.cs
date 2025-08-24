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
using DataAccess.Models;
using Service.UserService;

namespace PRN212_Assignment_01
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void LnkLogin(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();     
            this.Hide();      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Email = EmailTextBox.Text;
            var password = PasswordBox.Password;
            var CPassword = ConfirmPasswordBox.Password;
            if (!password.Equals(CPassword))
            {
                MessageBox.Show("Password not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AccountService accountService = new AccountService();
                bool result = accountService.AddCustomer(new DataAccess.Models.Customer(Email, password));

                if (result)
                {
                    MessageBox.Show("Register successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    new LoginWindow().Show();

                }
                else
                {
                    MessageBox.Show("Register failed! Username may already exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

       
    }
}
