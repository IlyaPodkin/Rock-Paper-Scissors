using Microsoft.EntityFrameworkCore;
using GrpcService.Models;
using GrpcService.Models.ModelsDTO;
using GrpcService.Data.SettingsDb;

namespace GrpcService.Data.Service
{
    public class UserService
    {
        protected readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool UpdateUser(Guid id, UserDto userDto)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return false;
            }
            user.Name = userDto.Name;
            user.Balance = userDto.Balance;
            user.CreatedAt = userDto.CreatedAt;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetUsers() => _context.Users.ToList();
    }
}
