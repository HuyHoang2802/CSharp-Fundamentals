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
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public bool AddRoom(RoomInformation roomInformation)
        {
            using var context = new FuminiHotelManagementContext();
            if(roomInformation == null)
            {
                return false;
            }
            context.RoomInformations.Add(roomInformation);
            context.SaveChanges();
            return true;
        }

        public bool DeleteRoom(int id)
        {
            using var context = new FuminiHotelManagementContext();
            var room = context.RoomInformations.Include(r => r.BookingDetails).FirstOrDefault(r => r.RoomId == id);
            if (room == null)
            {
                return false;
            }

            if (room.BookingDetails.Any())
            {
                room.RoomStatus = 0; // Set status to 0 (inactive) instead of deleting
                context.SaveChanges();
                return true;
            }
            context.Remove(room);
            context.SaveChanges();
            return true;
        }

        public List<RoomInformation> GetListRoom()
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.Include(r => r.RoomType).ToList();
        }

        public RoomInformation? GetRoomById(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.FirstOrDefault(r => r.RoomId == id);
        }

        public List<RoomInformation> SearchListRoom(string roomNumber)
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.Where(r => r.RoomNumber.Contains(roomNumber)).ToList();
        }

        public bool UpdateRoom(RoomInformation roomInformation)
        {
            using var context = new FuminiHotelManagementContext();
            var existingRoom = context.RoomInformations.FirstOrDefault(r => r.RoomId == roomInformation.RoomId);
            if (existingRoom == null)
            {
                return false;
            }

            existingRoom.RoomNumber = roomInformation.RoomNumber;
            existingRoom.RoomDetailDescription = roomInformation.RoomDetailDescription;
            existingRoom.RoomMaxCapacity = roomInformation.RoomMaxCapacity;
            existingRoom.RoomTypeId = roomInformation.RoomTypeId;
            existingRoom.RoomStatus = roomInformation.RoomStatus;
            existingRoom.RoomPricePerDay = roomInformation.RoomPricePerDay;
            context.SaveChanges();
            return true;
        }
    }
}
