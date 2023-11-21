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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _ReservationService;

        public ReservationController(IReservationService ReservationService)
        {
            _ReservationService = ReservationService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _ReservationService.GetReservations();
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
        public ActionResult Create(Reservation reservation)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _ReservationService.Add(reservation);
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
    
