using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interface;
using ShoppingApp.Models.DTO;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO); 
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
        [HttpPost]
        [Route("Remove")]
        public IActionResult RemoveFromCart(CartDTO cartDTO) 
        {
            var result = _cartService.RemoveFromCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not remove from cart");
        }
    }
}
