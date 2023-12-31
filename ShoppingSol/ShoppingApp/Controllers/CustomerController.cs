﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Interface;
using ShoppingApp.Models.DTO;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
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
        public IActionResult Login(UserDTO userDTO)
        {
                var user = _userService.Login(userDTO);
                if (user != null)
                {
                    return Ok(user);
                }

            //ViewData["Message"] = "Invalid username or password";
                return Unauthorized("Invalid username or password");
        }
    }
}
