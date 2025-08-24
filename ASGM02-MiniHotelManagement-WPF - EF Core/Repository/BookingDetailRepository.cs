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
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public bool AddBookingDetail(BookingDetail bookingDetail)
        {
            using var context = new FuminiHotelManagementContext();
            try
            {
                context.BookingDetails.Add(bookingDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return false;
            }
        }

        public bool DeleteBookingDetail(int BookingId, int RoomId)
        {
            using var context = new FuminiHotelManagementContext();
            try
            {
                var bookingDetail = context.BookingDetails.FirstOrDefault(x => x.BookingReservationId == BookingId && x.RoomId == RoomId);
                if (bookingDetail == null)
                {
                    return false; // Booking detail not found
                }
                context.BookingDetails.Remove(bookingDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return false;
            }
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingDetails
                .Include(bd => bd.Room)
                .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br.Customer)
                .ToList();
        }

        public List<BookingDetail> GetBookingDetails()
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingDetails.ToList();
        }

        public List<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingDetails
                .Where(bd => bd.BookingReservationId == bookingId)
                .ToList();
        }

        public List<BookingDetail> GetBookingDetailsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingDetails
                .Where(bd => bd.StartDate >= startDate && bd.EndDate <= endDate)
                .Include(bd => bd.Room)
                .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br.Customer)
                .OrderByDescending(bd => bd.StartDate)
                .ToList();
        }

        public List<BookingDetail> GetBookingDetailsByRoomId(int roomId)
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingDetails
                .Where(bd => bd.RoomId == roomId)
                .ToList();
        }

        public bool UpdateBookingDetail(BookingDetail bookingDetail)
        {
            using var context = new FuminiHotelManagementContext();
            try
            {
                var existingBookingDetail = context.BookingDetails
                    .FirstOrDefault(bd => bd.BookingReservationId == bookingDetail.BookingReservationId && bd.RoomId == bookingDetail.RoomId);
                
                if (existingBookingDetail == null)
                {
                    return false; // Booking detail not found
                }
                // Update properties
                existingBookingDetail.StartDate = bookingDetail.StartDate;
                existingBookingDetail.EndDate = bookingDetail.EndDate;
                existingBookingDetail.ActualPrice = bookingDetail.ActualPrice;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return false;
            }
        }
    }
}
