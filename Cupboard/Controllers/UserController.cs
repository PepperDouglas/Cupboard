using Cupboard.Models.DTO;
using Cupboard.Models.Entities;
using Cupboard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cupboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet("/api/logout")]
        public IActionResult Logout() { 
            _userService.Logout();
            return Ok("Logged out");
        }

        [HttpGet("/api/login")]
        public IActionResult Login(UserLogin userDto) {
            try {
                var result = _userService.Login(userDto);
                if (result.Success == false) {
                    return BadRequest(result.Message);
                }
                return Ok("Logged in");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user) {
            try {
                var result = _userService.CreateUser(user);
                if (result.Success == false) {
                    return BadRequest(result.Message);
                }
                return Created();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username) {
            try {
                var user = _userService.ReadUser(username);
                if (user != null) {
                    return Ok(user); 
                } else {
                    return BadRequest("User not found");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) {
            try {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        public IActionResult DeleteUser(User username) {
            try {
                _userService.DeleteUser(username);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
