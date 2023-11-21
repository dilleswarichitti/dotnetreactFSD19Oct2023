using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Room
    {
        public int Id { get; set; }//identity GUID
        public bool IsAvailable { get; set; }//room is currently available or not
        public  RoomType PrefferedType { get; set; }//Type of Room
        public bool HasBalcony { get; set; }//room has balcony or not
        public int HotelId { get; set; }//Foreignkey of hotel 
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        public List<Reservation> Reservations { get; set; }
    } 
    public enum RoomType
    {
        StandardRoom,//Commontype of room
        DeluxeRoom,//extra Amenities
        FamilyRoom,//More beds suitable for family gathering
        ConnectingRoom,//Interconnected rooms
        OceanViewRoom,//room with a view of the ocean
    }
}
