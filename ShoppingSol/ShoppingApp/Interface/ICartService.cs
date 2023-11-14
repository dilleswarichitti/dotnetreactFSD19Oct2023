using ShoppingApp.Models.DTO;

namespace ShoppingApp.Interface
{
    public interface ICartService
    {
        bool AddToCart(CartDTO cartDTO);
        bool RemoveFromCart(CartDTO cartDTO);
    }
}
