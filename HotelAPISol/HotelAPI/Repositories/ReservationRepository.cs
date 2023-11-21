using HotelAPI.Context;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class ReservationRepository : IRepository<int, Reservation>
    {
        private readonly HotelContext _context;
        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }
        public Reservation Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reservation Delete(int key)
        {
            var reservation = GetById(key);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
                return reservation;
            }
            return null;
        }

        public IList<Reservation> GetAll()
        {
            if (_context.Reservations.Count() == 0)
                return null;
            return _context.Reservations.ToList();
        }

        public Reservation GetById(int key)
        {
            var reservation = _context.Reservations.SingleOrDefault(h => h.Id == key);
            return reservation;
        }

        public Reservation Update(Reservation entity)
        {
            var reservation = GetById(entity.Id);
            if (reservation != null)
            {
                _context.Entry<Reservation>(reservation).State = EntityState.Modified;
                _context.SaveChanges();
                return reservation;
            }
            return null;
        }
    }
}
    