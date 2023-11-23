using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.Extensions.Logging;

namespace HotelAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _hotelRepository;
        public HotelService(IRepository<int, Hotel> repository)
        {
            _hotelRepository = repository;
        }
        public Hotel Add(Hotel hotel)
        {
            if(hotel!=null)
            {
                var result = _hotelRepository.Add(hotel);
                return result;
            }
            return null;
        }
        public Hotel Delete(Hotel hotel)
        {
            var hotels = _hotelRepository.GetAll().FirstOrDefault(e => e.Id == hotel.Id);
            if (hotels != null)
            {
                var result = _hotelRepository.Delete(hotel.Id);
                if (result != null) return result;
            }
            return hotels;
        }
        public List<Hotel> GetHotels()
        {
            var hotels = _hotelRepository.GetAll();
            if (hotels != null)
            {
                return hotels.ToList();
            }
            throw new NotAvailableException();
        }
        public Hotel Update(Hotel hotel)
        {
            var hotels = _hotelRepository.GetAll().FirstOrDefault(e => e.Id == hotel.Id);
            if (hotels != null)
            {
                hotel.Price = hotel.Price;
                var result = _hotelRepository.Update(hotel);
                return result;
            }
            throw new Exception();
        }
    }
}
