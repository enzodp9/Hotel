using Hotel.Data;
using Hotel.Models;
using Hotel.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly HotelDbContext _context;

        public BookingServices(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings.Select(b => new BookingDTO
            {
                Id = b.Id.ToString(),
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
                TotalPrice = b.TotalPrice,
                PaymentMethod = b.PaymentMethod
            });
        }

        public async Task<BookingDTO> GetBookingById(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            return new BookingDTO
            {
                Id = booking.Id.ToString(),
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                TotalPrice = booking.TotalPrice,
                PaymentMethod = booking.PaymentMethod
            };
        }

        public async Task CreateBooking(CreateBookingDTO bookingDTO)
        {
            var guest = await _context.Guests.FindAsync(Guid.Parse(bookingDTO.GuestId));
            if (guest == null)
            {
                throw new Exception("Guest not found");
            }
            else
            {
                var booking = new Booking
                {
                    Id = new Guid(),
                    CheckIn = bookingDTO.CheckIn,
                    CheckOut = bookingDTO.CheckOut,
                    TotalPrice = bookingDTO.TotalPrice,
                    PaymentMethod = bookingDTO.PaymentMethod,
                    GuestId = Guid.Parse(bookingDTO.GuestId)
                };
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateBooking(Guid id, CreateBookingDTO bookingDTO)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            booking.CheckIn = bookingDTO.CheckIn;
            booking.CheckOut = bookingDTO.CheckOut;
            booking.TotalPrice = bookingDTO.TotalPrice;
            booking.PaymentMethod = bookingDTO.PaymentMethod;
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
