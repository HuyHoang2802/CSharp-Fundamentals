using BusinessObject;
using DataAcesssLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public List<RoomType> GetAllRoomTypes()
        {
            using var _context = new FuminiHotelManagementContext();
            return _context.RoomTypes.ToList();
        }
    }
}
