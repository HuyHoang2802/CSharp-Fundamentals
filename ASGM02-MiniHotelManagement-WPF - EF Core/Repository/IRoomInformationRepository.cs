using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetListRoom();
        List<RoomInformation> SearchListRoom(string roomNumber);
        RoomInformation? GetRoomById(int id);
        bool AddRoom(RoomInformation roomInformation);
        bool UpdateRoom(RoomInformation roomInformation);
        bool DeleteRoom(int id);
    }
}
