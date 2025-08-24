using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IRoomInformationRepository _roomInformationRepository;
        private readonly IBookingReservationRepository _bookingReservationRepository;

        public BookingDetailService()
        {
            _bookingDetailRepository = new BookingDetailRepository();
            _roomInformationRepository = new RoomInformationRepository();
            _bookingReservationRepository = new BookingReservationRepository();
        }
        public bool AddBookingDetail(BookingDetail bookingDetail)
        {
            bookingDetail.ActualPrice = _roomInformationRepository.GetRoomById(bookingDetail.RoomId).RoomPricePerDay * (bookingDetail.EndDate.DayNumber - bookingDetail.StartDate.DayNumber);
            _bookingReservationRepository.UpdateBookingPrice(bookingDetail.BookingReservationId, (decimal)bookingDetail.ActualPrice);
            return _bookingDetailRepository.AddBookingDetail(bookingDetail);
        }

        public bool DeleteBookingDetail(int BookingId, int RoomId)
        {
            return _bookingDetailRepository.DeleteBookingDetail(BookingId, RoomId);
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            return _bookingDetailRepository.GetAllBookingDetails();
        }

        public BookingDetail GetBookingDetailById(int BookingId, int RoomId)
        {
            throw new NotImplementedException();
        }

        public List<BookingDetail> GetBookingDetails(int BookingId, int RoomId)
        {
            return _bookingDetailRepository.GetBookingDetails();
        }

        public List<BookingDetail> GetBookingDetailsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            return _bookingDetailRepository.GetBookingDetailsByDateRange(startDate, endDate);
        }

        public bool UpdateBookingDetail(BookingDetail bookingDetail)
        {
            bookingDetail.ActualPrice = _roomInformationRepository.GetRoomById(bookingDetail.RoomId).RoomPricePerDay * (bookingDetail.EndDate.DayNumber - bookingDetail.StartDate.DayNumber);
            return _bookingDetailRepository.UpdateBookingDetail(bookingDetail);
        }
    }
}
