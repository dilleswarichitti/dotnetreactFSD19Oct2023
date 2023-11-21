using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class CustomerDTO
    {
            [Required(ErrorMessage = "Email cannot be empty")]
            public string Email { get; set; }
            public string? Name { get; set; } 
            public string? Address { get; set; }
            public string? PhoneNumber { get; set; }
            public string Role { get; set; }
            public string? Token { get; set; }
            [Required(ErrorMessage = "Password mandetory")]
            public string Password { get; set;}
    }
}
