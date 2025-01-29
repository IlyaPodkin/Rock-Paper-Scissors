using GrpcService.Data.Service;
using GrpcService.Data.SettingsDb;
using GrpcService.Models;
using GrpcService.Models.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrpcService.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _user;

        public UserController(UserService user, ApplicationContext context)
        {
            _user = user;
        }

        [HttpPost("user")]
        public IActionResult Create([FromBody] User user) 
        {
            User result = _user.CreateUser(user);
            if (result == null) 
            {
                return BadRequest("Пользователи не найдены");
            }
            return Ok(result);
        }

        [HttpGet("user")]
        public IActionResult Get() => Ok(_user.GetUsers());

        //[HttpGet("user/{id}")]
        //public IActionResult GetUser(Guid id) 
        //{
        //    User result = _context.Users.Find(id);
        //    if (result == null) 
        //    {
        //        BadRequest("Такого пользователя не существует");
        //    }
        //    return Ok(_context.Users.Find(id)); 
        //}

        [HttpPut("user/{id}")]
        public IActionResult Update([FromBody] UserDto userDto, Guid id) 
        {
            bool result = _user.UpdateUser(id, userDto);
            if (result == false) 
            {
                return BadRequest("Такого пользователя не существует");
            }
            return Ok();
        }

        [HttpDelete("user/{id}")]
        public IActionResult Delete(Guid id) 
        {
            bool result = _user.DeleteUser(id);
            if (result == false)
            {
                return BadRequest("Такого пользователя не существует");
            }
            return Ok();
        }
    }
}
