using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class HistoryBookingViewModel : BaseViewModel
    {
        private readonly IBookingReservationService _bookingReservationService;
        private ObservableCollection<BookingReservation> _bookingReservations;
        private string _displayError = string.Empty;
        private Customer? _currentCustomer;

        public Customer CurrentCustomer
        {
            get => _currentCustomer ?? (Customer)Application.Current.Properties["WpfApp.Customer"];
            set
            {
                _currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
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
        public ObservableCollection<BookingReservation> BookingReservations
        {
            get => _bookingReservations;
            set
            {
                _bookingReservations = value;
                OnPropertyChanged(nameof(BookingReservations));
            }
        }
        public ICommand LoadBookings { get; }

        public string Error => null;

        public HistoryBookingViewModel(IBookingReservationService bookingReservationService)
        {
            _bookingReservationService = bookingReservationService;
            BookingReservations = new ObservableCollection<BookingReservation>();
            DisplayError = string.Empty;
            LoadBookings = new RelayCommand(ExecuteLoadBookings);
            LoadBookings.Execute(null); // Load bookings when the view model is initialized
        }
        private void ExecuteLoadBookings(object obj)
        {
            try
            {
                var bookings = _bookingReservationService.GetBookingsByCustomerId(CurrentCustomer.CustomerId);
                BookingReservations.Clear();
                foreach (var booking in bookings)
                {
                    BookingReservations.Add(booking);
                }
                DisplayError = string.Empty;
            }
            catch (Exception ex)
            {
                DisplayError = $"Error loading bookings: {ex.Message}";
            }
        }
    }
}
