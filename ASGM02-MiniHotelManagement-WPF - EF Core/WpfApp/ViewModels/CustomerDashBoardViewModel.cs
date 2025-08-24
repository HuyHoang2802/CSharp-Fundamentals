using BusinessObject;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class CustomerDashBoardViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICustomerService _customerService;

        private object? _currentView;
        private string _welcomeMessage;
        private Customer _currentCustomer;

        public Customer CurrentCustomer
        {
            get => _currentCustomer ?? (Customer?)Application.Current.Properties["WpfApp.Customer"];
            set
            {
                _currentCustomer = value;
                Application.Current.Properties["WpfApp.Customer"] = value;
                OnPropertyChanged();
                WelcomeMessage = _currentCustomer != null ? $"Welcome, {_currentCustomer.CustomerFullName}!" : "Welcome, Guest!";
            }
        }
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set { _welcomeMessage = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCommand { get; }
        public CustomerDashBoardViewModel(IServiceProvider serviceProvider, ICustomerService customerService)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));

           
            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object? parameter)
        {
            if (parameter is string viewName)
            {
                switch (viewName)
                {
                    case "Profile":
                        if (CurrentCustomer == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin khách hàng!");
                            return;
                        }
                        var customer = CurrentCustomer;
                        var customerWindow = new CustomerDialogWindow(customer, isNew: false);
                        if (customerWindow.ShowDialog() == false)
                        {
                            return;
                        }
                        _customerService.UpdateCustomer(customer);
                        CurrentCustomer = customer; // Update the current customer after editing
                        break;
                    case "History":
                        CurrentView = _serviceProvider.GetRequiredService<HistoryBookingView>();
                        break;
                    case "Logout":
                        Application.Current.Properties["WpfApp.Customer"] = null;
                        LoginWindow loginWindow = new();
                        loginWindow.Show();
                        foreach (var window in System.Windows.Application.Current.Windows)
                        {
                            if (window is CustomerDashBoardWindow)
                            {
                                ((CustomerDashBoardWindow)window).Close();
                                break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
