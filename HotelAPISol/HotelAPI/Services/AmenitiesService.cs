using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Repositories;

namespace HotelAPI.Services
{
    public class AmenitiesService : IAmenitiesService
    {
        private readonly IRepository<int, Amenities> _amenitiesRepository;
        public AmenitiesService(IRepository<int, Amenities> repository)
        {
            _amenitiesRepository = repository;
        }
        public Amenities Add(Amenities amenities)
        {
            var newAmentities = new Amenities
            {
                IsWifi = amenities.IsWifi,
                IsRoomService = amenities.IsRoomService,
                Name = amenities.Name,
                HotelId = amenities.HotelId
            };
            _amenitiesRepository.Add(newAmentities);
            return newAmentities;
        }

        public List<Amenities> GetAmenities()
        {
            var Amenities = _amenitiesRepository.GetAll();
            if (Amenities != null)
            {
                return Amenities.ToList();
            }
            throw new NotAvailableException();
        }
    }
}
