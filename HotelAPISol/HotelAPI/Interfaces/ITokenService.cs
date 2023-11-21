using HotelAPI.Models.DTO;
using static HotelAPI.Models.DTO.CustomerDTO;

namespace HotelAPI.Interfaces
{
    public interface ITokenService
    {
        string GetToken(CustomerDTO customer);
    }
}
