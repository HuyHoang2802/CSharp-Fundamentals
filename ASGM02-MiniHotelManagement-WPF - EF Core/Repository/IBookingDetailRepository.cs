using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetBookingDetailsByRoomId(int roomId);
        List<BookingDetail> GetAllBookingDetails();
        List<BookingDetail> GetBookingDetailsByBookingId(int bookingId);
        List<BookingDetail> GetBookingDetailsByDateRange(DateOnly startDate, DateOnly endDate);
        bool AddBookingDetail(BookingDetail bookingDetail);
        bool UpdateBookingDetail(BookingDetail bookingDetail);
        bool DeleteBookingDetail(int BookingId, int RoomId);
        List<BookingDetail> GetBookingDetails();
    }
}
