using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingDetailService
    {
        // Define methods for booking detail service here
        List<BookingDetail> GetAllBookingDetails();
        List<BookingDetail> GetBookingDetails(int BookingId, int RoomId);
        BookingDetail GetBookingDetailById(int BookingId, int RoomId);
        List<BookingDetail> GetBookingDetailsByDateRange(DateOnly startDate, DateOnly endDate);
        bool AddBookingDetail(BookingDetail detail);
        bool UpdateBookingDetail(BookingDetail bookingDetail);
        bool DeleteBookingDetail(int BookingId, int RoomId);
    }
}
