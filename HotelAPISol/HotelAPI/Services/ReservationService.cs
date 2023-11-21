using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;

namespace HotelAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<int, Reservation> _reservationRepository;

        public Reservation Add(Reservation reservation)
        {
            var newreservation = new Reservation();
            {
                if (reservation != null)
                {
                    var result = _reservationRepository.Add(reservation);
                    return result;
                }
                return null;
            }
        }
        public List<Reservation> GetReservations()
        {
            var reservation = _reservationRepository.GetAll();
            if (reservation != null)
            {
                return reservation.ToList();
            }
            throw new NotAvailableException();
        }
    }
}
