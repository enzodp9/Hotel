using Hotel.Models;
using Hotel.Services.DTOs;

namespace Hotel.Services
{
    public interface IGuestServices
    {
        Task<IEnumerable<GuestDTO>> GetGuests();
        Task<GuestDTO> GetGuestById(Guid id);
        Task CreateGuest(CreateGuestDTO guest);
        Task UpdateGuest(Guid id, CreateGuestDTO guest);
        Task DeleteGuest(Guid id);
    }
}
