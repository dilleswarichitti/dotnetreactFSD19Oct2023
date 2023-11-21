using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetReservations();
        Reservation Add(Reservation reservation);
    }
}
