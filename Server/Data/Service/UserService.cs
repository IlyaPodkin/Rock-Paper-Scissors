using Microsoft.EntityFrameworkCore;
using GrpcService.Models;
using GrpcService.Models.ModelsDTO;
using GrpcService.Data.SettingsDb;

namespace GrpcService.Data.Service
{
    public class UserService : IService<User, UserDto>
    {
        protected readonly ApplicationContext _context;

        public UserService(ApplicationContext context) => _context = context;

        public async Task<User> Create(User user)
        {
            User result = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (result != null)
            {
                return null;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Update(Guid id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.Name = userDto.Name;
            user.Balance = userDto.Balance;
            user.CreatedAt = userDto.CreatedAt;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> Get() => await _context.Users.ToListAsync();
        public async Task<User> GetElement(Guid id) => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

    }
}
