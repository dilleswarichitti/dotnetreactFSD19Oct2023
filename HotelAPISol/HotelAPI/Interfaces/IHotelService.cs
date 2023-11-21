using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();
        Hotel Add(Hotel hotel);
        Hotel Update(Hotel hotel);
        Hotel Delete(Hotel hotel);
    }
}
