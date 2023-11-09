using ShoppingApp.Models.DTO;

namespace ShoppingApp.Interface
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
