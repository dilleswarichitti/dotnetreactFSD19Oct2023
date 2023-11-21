using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Repositories;

namespace HotelAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _roomRepository;
        public RoomService(IRepository<int, Room> repository)
        {
            _roomRepository = repository;
        }
        public Room Add(Room room)
        {
            var newRoom = new Room
            {
                IsAvailable = room.IsAvailable,
                PrefferedType = room.PrefferedType,
                HasBalcony = room.HasBalcony,
                HotelId = room.HotelId
            };
            _roomRepository.Add(newRoom);
            return newRoom;
        }
        public List<Room> GetRooms()
        {
            var rooms = _roomRepository.GetAll();
            if (rooms != null)
            {
                return rooms.ToList();
            }
            throw new NotAvailableException();
        }
    }
}
