using BusinessObject;
using DataAcesssLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IBookingReservationRepository _bookings;
        private readonly IBookingDetailRepository _bookingDetails;
        private readonly IRoomInformationRepository _roomInformationRepository;
        public BookingReservationService() 
        {
            _bookings = new BookingReservationRepository();
            _bookingDetails = new BookingDetailRepository();
            _roomInformationRepository = new RoomInformationRepository();
        }
        public List<BookingReservation> GetAllBookings()
        {
            return _bookings.GetAllBookings();
        }

        public BookingReservation GetBookingById(int id)
        {
            return _bookings.GetBookingById(id);
        }

        public bool AddBooking(BookingReservation bookingReservation)
        {
            return _bookings.AddBooking(bookingReservation);
        }

        public List<BookingReservation> GetBookingsByCustomerId(int customerId)
        {
            return _bookings.GetBookingsByCustomerId(customerId);
        }

        public bool CreateBooking(int customerId, DateOnly bookingDate, List<(int RoomId, DateOnly StartDate, DateOnly EndDate, decimal ActualPrice)> roomDetails)
        {
            try
            {
                if (customerId <= 0 || bookingDate == default || !roomDetails.Any())
                {
                    return false;
                }
                var availableRooms = GetAvailableRooms(roomDetails.Min(r => r.StartDate), roomDetails.Max(r => r.EndDate));
                var availableRoomIds = availableRooms.Select(r => r.RoomId).ToList();
                if (roomDetails.Any(rd => !availableRoomIds.Contains(rd.RoomId)))
                {
                    return false; // Có phòng không khả dụng
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating booking: {ex.Message}");
                return false;
            }
        }

        public List<RoomInformation> GetAvailableRooms(DateOnly startDate, DateOnly endDate)
        {
            return _bookings.GetAvailableRooms(startDate, endDate);
        }

        public bool DeleteBooking(int id)
        {
            return _bookings.DeleteBooking(id);
        }

        public bool UpdateBooking(BookingReservation bookingReservation)
        {
            return _bookings.UpdateBooking(bookingReservation);
        }

        public List<BookingReservation> SearchListBooking(string customerName)
        {
            return _bookings.SearchListBooking(customerName);
        }
    }
}
