using Hotel.Models;
using Hotel.Services.DTOs;

namespace Hotel.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task CreateUser(CreateUserDTO userDTO);
        Task UpdateUser(Guid id, CreateUserDTO userDTO);
        Task DeleteUser(Guid id);
    }
}
