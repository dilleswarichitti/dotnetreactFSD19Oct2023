using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.GetHotels();
                _logger.LogInformation("hotels listed");
                return Ok(result);
            }
            catch (NotAvailableException e)
            {
                errorMessage = e.Message;
                _logger.LogError(errorMessage);
            }
            return BadRequest(errorMessage);
        }
        [Authorize(Roles = "customer")]
        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.Add(hotel);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPut]
        public ActionResult Update(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.Update(hotel);
                return Ok(hotel);
            }
            catch (CantUpdateException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        [HttpDelete]
        public ActionResult Remove(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.Delete(hotel);
                return Ok(hotel);
            }
            catch (CantRemoveException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
