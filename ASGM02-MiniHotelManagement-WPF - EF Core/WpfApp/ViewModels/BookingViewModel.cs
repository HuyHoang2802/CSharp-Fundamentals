using BusinessObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class BookingViewModel : BaseViewModel, IDataErrorInfo
    {
        private BookingReservation _bookingReservation;
        private readonly bool _isNew;
        private ObservableCollection<Customer> _customers;
        private readonly Window _window;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public int CustomerId
        {
            get => _bookingReservation.CustomerId;
            set
            {
                _bookingReservation.CustomerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }

        public DateOnly BookingDate
        {
            get => _bookingReservation.BookingDate;
            set
            {
                _bookingReservation.BookingDate = value;
                OnPropertyChanged(nameof(BookingDate));
            }
        }

        public decimal? TotalPrice
        {
            get => _bookingReservation.TotalPrice;
            set
            {
                _bookingReservation.TotalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public byte? Status
        {
            get => _bookingReservation.BookingStatus;
            set
            {
                _bookingReservation.BookingStatus = value;
                OnPropertyChanged(nameof(Status));
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
                    case nameof(CustomerId):
                        if (CustomerId <= 0)
                            return "Vui lòng chọn khách hàng.";
                        break;
                    case nameof(TotalPrice):
                        if (!TotalPrice.HasValue || TotalPrice < 0)
                            return "Tổng tiền phải ≥ 0.";
                        break;
                    case nameof(BookingDate):
                        if (BookingDate > DateOnly.FromDateTime(DateTime.Today))
                            return "Ngày đặt không được lớn hơn hôm nay.";
                        break;
                }
                return null;
            }
        }

        public BookingViewModel(BookingReservation bookingReservation, bool isNew, List<Customer> customers, Window Window)
        {
            _bookingReservation = bookingReservation;
            _isNew = isNew;
            _window = Window;
            Customers = new ObservableCollection<Customer>(customers);

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
