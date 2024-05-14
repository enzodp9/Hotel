using Hotel.Data;
using Hotel.Models;
using Hotel.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class UserServices : IUserServices
    {
        private readonly HotelDbContext _context;

        public UserServices(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id.ToString(),
                Username = u.Username,
                Email = u.Email,
                Password = u.Password,
                Role = u.Role
            });
        }


        public async Task CreateUser(CreateUserDTO userDTO)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, CreateUserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Email = userDTO.Email;
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.Role = userDTO.Role;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            Console.WriteLine("User deleted");
            await _context.SaveChangesAsync();
        }
    }
}
