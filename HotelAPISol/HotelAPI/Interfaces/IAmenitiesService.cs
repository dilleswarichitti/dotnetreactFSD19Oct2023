using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IAmenitiesService
    {
        List<Amenities> GetAmenities();
        Amenities Add(Amenities amenities);
    }
}
