using Hotel.Models;
using Hotel.Services.DTOs;

namespace Hotel.Services
{
    public interface IBookingServices
    {
        Task<IEnumerable<BookingDTO>> GetBookings();
        Task<BookingDTO> GetBookingById(Guid id);
        Task CreateBooking(CreateBookingDTO bookingDTO);
        Task UpdateBooking(Guid id, CreateBookingDTO bookingDTO);
        Task DeleteBooking(Guid id);
    }
}
