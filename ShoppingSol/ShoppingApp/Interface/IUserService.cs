using ShoppingApp.Models.DTO;

namespace ShoppingApp.Interface
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}
