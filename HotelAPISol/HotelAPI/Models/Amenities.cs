using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Amenities
    {
        public int Id { get; set; }//identity GUID
        public string Name { get; set; }//Name of the Amenity
        public string Description { get; set; }//Details about Amenities
        public bool IsWifi { get; set; }
        public bool IsRoomService { get; set; } 
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

    }
}
