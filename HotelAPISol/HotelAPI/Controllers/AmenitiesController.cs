using HotelAPI.Exceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {

        private readonly IAmenitiesService _AmenitiesService;
        public AmenitiesController(IAmenitiesService AmenitiesService)
        {
            _AmenitiesService = AmenitiesService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _AmenitiesService.GetAmenities();
                return Ok(result);
            }
            catch (NotAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [Authorize(Roles = "customer")]
        [HttpPost]
        public ActionResult Create(Amenities amenities)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _AmenitiesService.Add(amenities);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
