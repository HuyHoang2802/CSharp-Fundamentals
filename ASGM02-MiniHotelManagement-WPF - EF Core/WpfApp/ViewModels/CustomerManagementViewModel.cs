using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class CustomerManagementViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private ObservableCollection<Customer> _customers;
        private string _displayError = string.Empty;
        private string _keyword = string.Empty;

        public string Keyword
        {
            get => _keyword;
            set
            {
                _keyword = value;
                OnPropertyChanged();
                ExecuteSearchCustomer();
            }
        }

        public string DisplayError
        {
            get => _displayError;
            set
            {
                _displayError = value;
                OnPropertyChanged(nameof(DisplayError));
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        public ICommand LoadCustomer { get; }
        public ICommand AddCustomer { get; }
        public ICommand UpdateCustomer { get; }
        public ICommand DeleteCustomer { get; }
        public ICommand SearchCustomer { get; }

        public CustomerManagementViewModel(ICustomerService customerService)
        {
            _customerService = customerService;

            Customers = new ObservableCollection<Customer>();
            DisplayError = string.Empty;

            LoadCustomer = new RelayCommand(ExecuteLoadCustomer);
            AddCustomer = new RelayCommand(ExecuteAddCustomer);
            UpdateCustomer = new RelayCommand(ExecuteUpdateCustomer);
            DeleteCustomer = new RelayCommand(ExecuteDeleteCustomer);

            LoadCustomer.Execute(null); // Load customers when the view model is initialized
        }

        private void ExecuteLoadCustomer(object? parameter)
        {
            Customers.Clear();  
            var customers = _customerService.GetAllCustomers();
            if(customers != null)
            {
                foreach (var customer in customers) // Assuming GetAllCustomers returns 
                {
                    Customers.Add(customer);
                }
            }
            
            else
            {
               DisplayError = "No Content";
            }
        }

        public void ExecuteAddCustomer(object? parameter)
        {
            var customer = new Customer(); // Create a new customer instance
            var customerWindow = new CustomerDialogWindow(customer, isNew: false);
            if (customerWindow.ShowDialog() == false)
            {
                DisplayError = "Failed to update customer.";
                return;
            }

            _customerService.AddCustomer(customer);
            LoadCustomer.Execute(null); // Reload customers after add
        }

        public void ExecuteUpdateCustomer(object? parameter)
        {
            if (parameter is Customer customer)
            {
                var customerWindow = new CustomerDialogWindow(customer, isNew: false);
                if (customerWindow.ShowDialog() == false)
                {
                    DisplayError = "Failed to update customer.";
                    return;
                }

                _customerService.UpdateCustomer(customer);
                LoadCustomer.Execute(null); // Reload customers after update
            }
            else
            {
                DisplayError = "No customer selected for update.";
            }
        }

        public void ExecuteDeleteCustomer(object? parameter)
        {
            if (parameter is Customer customer && MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {customer.CustomerFullName}?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (_customerService.DeleteCustomer(customer.CustomerId))
                {
                    LoadCustomer.Execute(null); // Reload customers after deletion
                }
                else
                {
                    DisplayError = "Failed to delete customer.";
                }
            }
        }

        private void ExecuteSearchCustomer()
        {
            if(Keyword!=null)
            {
                Customers.Clear();
                var customers = _customerService.SearchCustomer(Keyword);
                if (customers != null)
                {
                    foreach (var customer in customers) // Assuming GetAllCustomers returns 
                    {
                        Customers.Add(customer);
                    }
                }

                else
                {
                    DisplayError = "No Content";
                }
            }
        }
    }
}
