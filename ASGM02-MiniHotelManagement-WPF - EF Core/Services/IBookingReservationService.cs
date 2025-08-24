using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingReservationService
    {
        List<BookingReservation> GetAllBookings();
        List<BookingReservation> GetBookingsByCustomerId(int customerId);
        List<BookingReservation> SearchListBooking(string customerName);
        BookingReservation GetBookingById(int id);
        bool AddBooking(BookingReservation bookingReservation);
        bool CreateBooking(int customerId, DateOnly bookingDate, List<(int RoomId, DateOnly StartDate, DateOnly EndDate, decimal ActualPrice)> roomDetails);
        bool DeleteBooking(int id);

        bool UpdateBooking(BookingReservation bookingReservation);

        List<RoomInformation> GetAvailableRooms(DateOnly startDate, DateOnly endDate);
    }
}
