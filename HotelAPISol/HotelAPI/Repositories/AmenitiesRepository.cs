using HotelAPI.Context;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class AmenitiesRepository : IRepository<int, Amenities>
    {
        private readonly HotelContext _context;
        public AmenitiesRepository(HotelContext context)
        {
            _context = context;
        }
        public Amenities Add(Amenities entity)
        {
            _context.Amenities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Amenities Delete(int key)
        {
            var amenities = GetById(key);
            if (amenities != null)
            {
                _context.Amenities.Remove(amenities);
                _context.SaveChanges();
                return amenities;
            }
            return null;
        }

        public IList<Amenities> GetAll()
        {
            if (_context.Amenities.Count() == 0)
                return null;
            return _context.Amenities.ToList();
        }

        public Amenities GetById(int key)
        {
            var amenities = _context.Amenities.SingleOrDefault(h => h.Id == key);
            return amenities;
        }

        public Amenities Update(Amenities entity)
        {
            var amenities = GetById(entity.Id);
            if (amenities != null)
            {
                _context.Entry<Amenities>(amenities).State = EntityState.Modified;
                _context.SaveChanges();
                return amenities;
            }
            return null;
        }
    }
}

