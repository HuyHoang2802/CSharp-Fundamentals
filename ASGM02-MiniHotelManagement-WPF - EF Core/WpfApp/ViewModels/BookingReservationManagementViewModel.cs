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

namespace WpfApp.ViewModels
{
    public class BookingReservationManagementViewModel : BaseViewModel
    {
        private readonly IBookingReservationService _bookingReservationService;
        private readonly ICustomerService _customerService;
        private readonly IRoomInformationService _roomInformationService;
        private readonly IBookingDetailService _bookingDetailService;
        private ObservableCollection<BookingReservation> _bookingReservations;
        private string _displayError = string.Empty;
        private string _keyword = string.Empty;

        public string Keyword
        {
            get => _keyword;
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(Keyword));
                ExecuteSearchBooking();
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
        public ICommand AddBooking { get; }
        public ICommand AddBookingDetail { get; }
        public ICommand UpdateBooking { get; }
        public ICommand DeleteBooking { get; }
        public BookingReservationManagementViewModel(IBookingReservationService bookingReservationService, ICustomerService customerService, IRoomInformationService roomInformationService, IBookingDetailService bookingDetailService)
        {
            _bookingReservationService = bookingReservationService;
            _customerService = customerService;
            _roomInformationService = roomInformationService;
            _bookingDetailService = bookingDetailService;
            BookingReservations = new ObservableCollection<BookingReservation>();
            DisplayError = string.Empty;
            LoadBookings = new RelayCommand(ExecuteLoadBookings);
            AddBooking = new RelayCommand(ExecuteAddBooking);
            UpdateBooking = new RelayCommand(ExecuteUpdateBooking);
            DeleteBooking = new RelayCommand(ExecuteDeleteBooking);
            AddBookingDetail = new RelayCommand(ExecuteAddBookingDetail);

            LoadBookings.Execute(null); // Load bookings when the view model is initialized
        }
        private void ExecuteLoadBookings(object obj)
        {
            try
            {
                var bookings = _bookingReservationService.GetAllBookings();
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
        private void ExecuteAddBooking(object obj)
        {
            var bookingReservation = new BookingReservation();
            var customers = new List<Customer>(_customerService.GetAllCustomers());
            var dialog = new Views.BookingReservationDialogWindow(bookingReservation, false, customers);
            if(dialog.ShowDialog() == true)
            {
 
                    _bookingReservationService.AddBooking(bookingReservation);
                    LoadBookings.Execute(null); // Refresh the booking list
                    DisplayError = string.Empty;

            }
        }
        private void ExecuteUpdateBooking(object obj)
        {
            if (obj is BookingReservation booking)
            {
                var customers = new List<Customer>(_customerService.GetAllCustomers());
                var dialog = new Views.BookingReservationDialogWindow(booking, true, customers);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        _bookingReservationService.UpdateBooking(booking);
                        LoadBookings.Execute(null); // Refresh the booking list
                        DisplayError = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        DisplayError = $"Error updating booking: {ex.Message}";
                    }
                }
            }
            else
            {
                DisplayError = "Invalid booking selected for update.";
            }
        }
        private void ExecuteDeleteBooking(object obj)
        {
            if (obj is BookingReservation booking && MessageBox.Show($"Bạn có chắc muốn xóa lịch hẹn ngày {booking.BookingDate}?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                        _bookingReservationService.DeleteBooking(booking.BookingReservationId);
                        LoadBookings.Execute(null); // Refresh the booking list
                        DisplayError = string.Empty;
                }
                catch (Exception ex)
                {
                    DisplayError = $"Error deleting booking: {ex.Message}";
                }
            }
            else
            {
                DisplayError = "Invalid booking selected for deletion.";
            }
        }

        private void ExecuteAddBookingDetail(object obj)
        {
            if (obj is BookingReservation booking)
            {
                var newBookingDetail = new BookingDetail { BookingReservationId = booking.BookingReservationId };
                var rooms = new List<RoomInformation>(_roomInformationService.LoadRoomInformation());
                var dialog = new Views.BookingDetailDialogWindow(newBookingDetail, true, rooms);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        _bookingDetailService.AddBookingDetail(newBookingDetail);
                        LoadBookings.Execute(null); // Refresh the booking list
                        DisplayError = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        DisplayError = $"Error adding booking detail: {ex.Message}";
                    }
                }
            }
            else
            {
                DisplayError = "Invalid booking selected for adding detail.";
            }
        }

        private void ExecuteSearchBooking()
        {
            try
            {
                var bookings = _bookingReservationService.SearchListBooking(Keyword);
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
