using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetAllBookings();
        List<BookingReservation> GetBookingsByCustomerId(int customerId);
        List<BookingReservation> SearchListBooking(string customerName);
        BookingReservation? GetBookingById(int id);
        bool AddBooking(BookingReservation booking);
        bool UpdateBooking(BookingReservation booking);
        void UpdateBookingPrice(int bookingId, decimal newPrice);
        bool DeleteBooking(int id);
        List<RoomInformation> GetAvailableRooms(DateOnly startDate, DateOnly endDate);
    }
}
