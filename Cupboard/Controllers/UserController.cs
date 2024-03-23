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

        [HttpPost]
        public IActionResult CreateUser(User user) {
            try {
                var result = _userService.CreateUser(user);
                //Exception, status code, or flags
                //status code, since it is an expected occurance that a
                //new user enters an already taken name
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
