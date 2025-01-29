using GrpcService.Data.Service;
using GrpcService.Data.SettingsDb;
using GrpcService.Models;
using GrpcService.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace GrpcService.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _user;

        public UserController(UserService user, ApplicationContext context) => _user = user;

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] User user) 
        {
            User result = await _user.Create(user);
            if (result == null) 
            {
                return BadRequest("Пользователь с таким id уже существует");
            }
            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllUsers() => Ok(await _user.Get());

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            User result = await _user.GetElement(id);
            if (result == null)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok(result);
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto, Guid id) 
        {
            bool result = await _user.Update(id, userDto);
            if (result == false) 
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id) 
        {
            bool result = await _user.Delete(id);
            if (result == false)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }
    }
}
