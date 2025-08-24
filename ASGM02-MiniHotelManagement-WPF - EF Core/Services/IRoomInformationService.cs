using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomInformationService
    {
        IEnumerable<RoomInformation> LoadRoomInformation();
        List<RoomInformation> SearchRoomInformation(string roomNumber);
        RoomInformation? GetRoomInformationById(int id);
        bool AddRoomInformation(RoomInformation roomInformation);
        bool UpdateRoomInformation(RoomInformation roomInformation);
        bool DeleteRoomInformation(int id);
    }
}
