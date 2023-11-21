using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        Room Add(Room room); 
    }
}
