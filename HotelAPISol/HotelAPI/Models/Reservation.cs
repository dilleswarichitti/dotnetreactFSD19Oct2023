using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }//identity GUID
        public DateTime CheckInDate { get; set; }//On which date the customer want to arrives
        public DateTime CheckOutDate { get; set; } //The end Date of the Customer stay
        public DateTime CheckInTime { get; set; }//On which time customer arrives
        public DateTime CheckOutTime { get; set; } //Check Out Time
        public PaymentMethod paymentMethod { get; set; }
        public int RoomId { get; set; }//Foreign key of room
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public string Email { get; set; }//Foreign key of customer
        [ForeignKey("Email")]
        public Customer Customer { get; set; }
    }
    public enum PaymentMethod
    {
        CreditCard,
        GooglePay,
        DebitCard
    }
}
