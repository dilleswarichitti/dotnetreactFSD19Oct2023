using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}
