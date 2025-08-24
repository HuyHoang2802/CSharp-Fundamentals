using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class CustomerViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly Customer _customer;
        private readonly bool _isNew;
        private readonly Window _window;

        public string Name 
        { 
            get => _customer.CustomerFullName;
            set
            {
                _customer.CustomerFullName = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _customer.Telephone;
            set
            {
                _customer.Telephone = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _customer.EmailAddress;
            set
            {
                _customer.EmailAddress = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Birthday
        {
            get => _customer.CustomerBirthday?.ToDateTime(TimeOnly.MinValue);
            set
            {
                _customer.CustomerBirthday = value.HasValue ? DateOnly.FromDateTime(value.Value) : null;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _customer.Password;
            set
            {
                _customer.Password = value;
                OnPropertyChanged();
            }
        }

        public byte? Status
        {
            get => _customer.CustomerStatus;
            set
            {
                _customer.CustomerStatus = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public string Error => null;
        public string this[string columnName]
        {
            get
            {
            switch (columnName)
            {
                case nameof(Name):
                    if (string.IsNullOrWhiteSpace(Name))
                        return "Họ tên không được để trống.";
                    break;
                case nameof(Email):
                    if (string.IsNullOrWhiteSpace(Email))
                        return "Email không được để trống.";
                    if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        return "Email không đúng định dạng.";
                    break;
                case nameof(Phone):
                    if (string.IsNullOrWhiteSpace(Phone))
                        return "Số điện thoại không được để trống.";
                    if (!Regex.IsMatch(Phone, @"^\d{10,12}$"))
                        return "Số điện thoại không hợp lệ (10-12 chữ số).";
                    break;
                case nameof(Password):
                    if (string.IsNullOrWhiteSpace(Password) || Password.Length < 4)
                        return "Mật khẩu phải có ít nhất 4 ký tự.";
                    break;
            }

            return null;
            }
        }

        public CustomerViewModel(Customer customer, bool isNew, Window window)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
            _isNew = isNew;
            _window = window ?? throw new ArgumentNullException(nameof(window));

            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Save(object parameter)
        {
            var props = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor prop in props)
            {
                if (!string.IsNullOrEmpty(this[prop.Name]))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
                    return;
                }
            }

            _window.DialogResult = true;
            _window.Close();
        }

        public bool CanSave(object parameter)
        {
            return true;
        }

        public void Cancel(object parameter)
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
