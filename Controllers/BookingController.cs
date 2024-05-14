using Hotel.Services;
using Hotel.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices _bookingServices;

        public BookingController(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bookings = await _bookingServices.GetBookings();
                return Ok(bookings);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var bookings = await _bookingServices.GetBookingById(id);
                return Ok(bookings);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingDTO bookingDTO)
        {
            try
            {
                await _bookingServices.CreateBooking(bookingDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateBookingDTO bookingDTO)
        {
            try
            {
                await _bookingServices.UpdateBooking(id, bookingDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _bookingServices.DeleteBooking(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }

        }
    }
}
