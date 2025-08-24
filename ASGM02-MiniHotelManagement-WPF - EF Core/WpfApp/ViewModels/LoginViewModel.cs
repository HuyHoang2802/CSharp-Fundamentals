using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICustomerService _customerService;
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }
        public LoginViewModel(IConfiguration configuration, IServiceProvider serviceProvider, ICustomerService customerService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            LoginCommand = new RelayCommand(Login);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Login(object? parameter)
        {
            var adminEmail = App.GetAdminEmail();
            var adminPassword = App.GetAdminPassword();

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Email.Equals(adminEmail, StringComparison.OrdinalIgnoreCase) && Password.Equals(adminPassword, StringComparison.Ordinal))
            {
                AdminDashBoardWindow adminDashBoard = new();
                adminDashBoard.Show();
                if (parameter is Window loginWindow)
                {
                    loginWindow.Close();
                }
                return;
            }

            var customer = _customerService.AuthenticateCustomers(Email, Password);
            if (customer != null)
            {
                Application.Current.Properties["WpfApp.Customer"] = customer; // Store the current customer in application properties
                CustomerDashBoardWindow customerDashBoardWindow = _serviceProvider.GetRequiredService<CustomerDashBoardWindow>();
                customerDashBoardWindow.Show();

                if (parameter is Window loginWindow)
                {
                    loginWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
