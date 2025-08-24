using BusinessObject;
using DataAcesssLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public bool AddBooking(BookingReservation booking)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                if (booking == null || booking.CustomerId <= 0)
                {
                    Console.WriteLine("Error: Invalid booking reservation data.");
                    return false; // Kiểm tra dữ liệu hợp lệ
                }
                context.BookingReservations.Add(booking);
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteBooking(int id)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var booking = context.BookingReservations.Find(id);
                if (booking == null)
                {
                    return false;
                }
                context.BookingReservations.Remove(booking);
                context.SaveChanges();
                return true;
            }
        }

        public List<BookingReservation> GetAllBookings()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.BookingReservations
                            .Include(c => c.Customer)
                            .Include(b => b.BookingDetails)
                                .ThenInclude(d => d.Room)
                            .ToList(); // ← gọi ToList sau cùng!
            }
        }

        public List<RoomInformation> GetAvailableRooms(DateOnly startDate, DateOnly endDate)
        {
            using var context = new FuminiHotelManagementContext();
            var startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = endDate.ToDateTime(TimeOnly.MaxValue);

            var bookedRoomIds = context.BookingDetails
                .Where(bd => bd.StartDate <= endDate && bd.EndDate >= startDate)
                .Select(bd => bd.RoomId)
                .Distinct()
                .ToList();

            return context.RoomInformations
                .Include(r => r.RoomType)
                .Where(r => !bookedRoomIds.Contains(r.RoomId) && r.RoomStatus == 1) // 1 = Available
                .ToList();
        }

        public BookingReservation? GetBookingById(int id)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.BookingReservations.FirstOrDefault(b => b.BookingReservationId == id);
            }
        }

        public List<BookingReservation> GetBookingsByCustomerId(int customerId)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.BookingReservations
                            .Where(b => b.CustomerId == customerId)
                            .Include(c => c.Customer)
                            .Include(b => b.BookingDetails)
                                .ThenInclude(d => d.Room)
                            .ToList(); // ← gọi ToList sau cùng!
            }
        }

        public List<BookingReservation> GetBookingsByDate(DateOnly startDate, DateOnly endDate)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                return context.BookingReservations
                            .Include(c => c.Customer)
                            .Include(b => b.BookingDetails)
                                .ThenInclude(d => d.Room)
                            .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                            .ToList(); // ← gọi ToList sau cùng!
            }
        }

        public List<BookingReservation> SearchListBooking(string customerName)
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingReservations
                            .Include(c => c.Customer)
                            .Include(b => b.BookingDetails)
                                .ThenInclude(d => d.Room)
                            .Where(c => c.Customer.CustomerFullName.Contains(customerName))
                            .ToList(); 
        }

        public bool UpdateBooking(BookingReservation booking)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var existingBooking = context.BookingReservations.FirstOrDefault(br => br.BookingReservationId == booking.BookingReservationId);
                if (existingBooking == null)
                {
                    return false;
                }
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.TotalPrice = booking.TotalPrice;
                existingBooking.BookingStatus = booking.BookingStatus;
                existingBooking.BookingDate = booking.BookingDate;
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateBookingPrice(int bookingId, decimal newPrice)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var booking = context.BookingReservations.Find(bookingId);
                if (booking != null)
                {
                    booking.TotalPrice += newPrice;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Booking with ID {bookingId} not found.");
                }
            }
        }
    }
}
