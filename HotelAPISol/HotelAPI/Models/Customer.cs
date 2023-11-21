using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Customer
    {
        public string Name { get; set; }//Name of the customer
        public string Address { get; set; }//Address of the Customer(Current address)
        public string PhoneNumber {get;set;}//Phone Number of the Customer
        [Key]
        public string Email { get; set; }//Customer's Email address
        public byte[] Password { get; set; }//Password to login 
        public string Role { get; set; }
        public byte[] Key { get; set; }

    }
}
