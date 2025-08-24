using BusinessObject;
using Microsoft.Win32;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class ReportManagementViewModel : BaseViewModel
    {
        private readonly IBookingDetailService _bookingDetailService;
        private string _dispalyError;
        private DateOnly _startDay;
        private DateOnly _endDay;
        private ObservableCollection<BookingDetail> _bookingReservations;

        public DateOnly StartDate
        {
            get => _startDay;
            set
            {
                _startDay = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateOnly EndDate
        {
            get => _endDay;
            set
            {
                _endDay = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public ObservableCollection<BookingDetail> BookingDetails
        {
            get => _bookingReservations;
            set
            {
                _bookingReservations = value;
                OnPropertyChanged(nameof(BookingDetails));
            }
        }

        public string DisplayError
        {
            get => _dispalyError;
            set
            {
                _dispalyError = value;
                OnPropertyChanged(nameof(DisplayError));
            }
        }

        public ICommand LoadBookingCommand { get; set; }
        public ICommand ExportReportCommand { get; set; } // Placeholder for export command

        public ReportManagementViewModel(IBookingDetailService bookingDetailService)
        {
            _bookingDetailService = bookingDetailService;

            StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            BookingDetails = new ObservableCollection<BookingDetail>();
            DisplayError = string.Empty;

            LoadBookingCommand = new RelayCommand(LoadBookings);
            ExportReportCommand = new RelayCommand(ExportReport);

            LoadBookingCommand.Execute(null); // Load bookings when the view model is initialized
        }

        private void LoadBookings(object? parameter)
        {
            try
            {
                if (EndDate <= StartDate)
                {
                    DisplayError = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.";
                    return;
                }
                var bookings = _bookingDetailService.GetBookingDetailsByDateRange(StartDate, EndDate);
                BookingDetails.Clear();
                foreach (var booking in bookings)
                {
                    BookingDetails.Add(booking);
                }
                DisplayError = string.Empty;
            }
            catch (Exception ex)
            {
                DisplayError = $"Error loading bookings: {ex.Message}";
            }
        }

        private void ExportReport(object? parameter)
        {
            try
            {
                if (BookingDetails.Count == 0)
                {
                    DisplayError = "Không có dữ liệu để xuất báo cáo.";
                    return;
                }
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = $"BookingReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var csv = new StringBuilder();
                    csv.AppendLine("Ngày đặt,Tổng tiền,Tên khách hàng,Ngày bắt đầu,Ngày kết thúc,Số phòng,Trạng thái");

                    foreach (var booking in BookingDetails)
                    {
                        var bookingDate = booking.BookingReservation?.BookingDate.ToString("dd/MM/yyyy") ?? "N/A";
                        var totalPrice = booking.BookingReservation?.TotalPrice.ToString() ?? "0";
                        var customerName = booking.BookingReservation?.Customer?.CustomerFullName ?? "Không có thông tin";
                        var startDate = booking.StartDate.ToString("dd/MM/yyyy");
                        var endDate = booking.EndDate.ToString("dd/MM/yyyy");
                        var roomNumber = booking.Room?.RoomNumber ?? "N/A";
                        var status = booking.BookingReservation?.BookingStatus == 1 ? "Booked" : "not";
                        csv.AppendLine($"\"{bookingDate}\",\"{totalPrice}\",\"{customerName}\",\"{startDate}\",\"{endDate}\",\"{roomNumber}\",\"{status}\"");
                    }
                    File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                    DisplayError = "Xuất báo cáo thành công!";
                }

            }
            catch (Exception ex)
            {
                DisplayError = $"Error exporting report: {ex.Message}";
            }
        }
    }
}
