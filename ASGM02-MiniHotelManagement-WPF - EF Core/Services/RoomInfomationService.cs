using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInfomationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository _roomInformationRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        public RoomInfomationService()
        {
            _roomInformationRepository = new RoomInformationRepository();
            _bookingDetailRepository = new BookingDetailRepository();
        }
        public bool AddRoomInformation(RoomInformation roomInformation)
        {
            return _roomInformationRepository.AddRoom(roomInformation);
        }

        public bool DeleteRoomInformation(int id)
        {
            return _roomInformationRepository.DeleteRoom(id);
        }

        public RoomInformation? GetRoomInformationById(int id)
        {
            return _roomInformationRepository.GetRoomById(id);
        }

        public IEnumerable<RoomInformation> LoadRoomInformation()
        {
            return _roomInformationRepository.GetListRoom();
        }

        public List<RoomInformation> SearchRoomInformation(string roomNumber)
        {
            return _roomInformationRepository.SearchListRoom(roomNumber);
        }

        public bool UpdateRoomInformation(RoomInformation roomInformation)
        {
            return _roomInformationRepository.UpdateRoom(roomInformation);
        }
    }
}
