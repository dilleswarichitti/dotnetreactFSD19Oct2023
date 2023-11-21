using HotelAPI.Interfaces;
using HotelAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public ActionResult Register(CustomerDTO viewModel)
        {
            string message = "";
            try
            {
                var customer = _customerService.Register(viewModel);
                if (customer != null)
                {
                    return Ok(customer);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }

            return BadRequest(message);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(CustomerDTO customerDTO)
        {
            var customer = _customerService.Login(customerDTO);
            if (customer != null)
            {
                return Ok(customer);
            }
            //ViewData["Message"] = "Invalid username or password";
            return Unauthorized("Invalid username or password");
        }
    }
}

