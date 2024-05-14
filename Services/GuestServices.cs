using Hotel.Data;
using Hotel.Models;
using Hotel.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hotel.Services
{
    public class GuestServices : IGuestServices
    {
        private readonly HotelDbContext _context;

        public GuestServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GuestDTO>> GetGuests()
        {
            var guests = await _context.Guests.ToListAsync();
            return guests.Select(g => new GuestDTO
            {
                Id = g.Id.ToString(),
                FirstName = g.FirstName,
                LastName = g.LastName,
                DateOfBirth = g.DateOfBirth.ToString(),
                Nationality = g.Nationality,
                Phone = g.Phone
            });
        }

        public async Task<GuestDTO> GetGuestById(Guid id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                throw new Exception("Guest not found");
            }
            return new GuestDTO
            {
                Id = guest.Id.ToString(),
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                DateOfBirth = guest.DateOfBirth.ToString(),
                Nationality = guest.Nationality,
                Phone = guest.Phone
            };
        }

        public async Task CreateGuest(CreateGuestDTO guestDTO)
        {
            var guest = new Guest
            {
                Id = new Guid(),
                FirstName = guestDTO.FirstName,
                LastName = guestDTO.LastName,
                DateOfBirth = DateTime.Parse(guestDTO.DateOfBirth),
                Nationality = guestDTO.Nationality,
                Phone = guestDTO.Phone
            };
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuest(Guid id, CreateGuestDTO guestDTO)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                throw new Exception("Guest not found");
            }
            guest.FirstName = guestDTO.FirstName;
            guest.LastName = guestDTO.LastName;
            guest.DateOfBirth = DateTime.Parse(guestDTO.DateOfBirth);
            guest.Nationality = guestDTO.Nationality;
            guest.Phone = guestDTO.Phone;
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuest(Guid id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                throw new Exception("Guest not found");
            }
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }
}
