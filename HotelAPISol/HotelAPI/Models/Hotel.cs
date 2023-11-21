using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }//identity GUID 
        [Required(ErrorMessage = "Name of the Hotel cannot be empty")]
        public string Name { get; set; }//Name of the Hotel
        public string Location { get; set; }//Location of the Hotel
        public float Price { get; set; }//Price of the room in hotel
        public double Rating { get; set; }//Rating of the hotel
        public float Discount { get; set; }//Discount available 
        public string picture { get; set; } //picture of the hotel
        public List<Room> Rooms { get; set; }
        public List<Amenities> Amenities { get; set;}
    }
}
