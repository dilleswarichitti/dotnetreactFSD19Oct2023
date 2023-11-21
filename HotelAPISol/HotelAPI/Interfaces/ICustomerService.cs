using HotelAPI.Models.DTO;
using static HotelAPI.Models.DTO.CustomerDTO;

namespace HotelAPI.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO Login(CustomerDTO customerDTO); 
        CustomerDTO Register(CustomerDTO customerDTO);
    }
}
