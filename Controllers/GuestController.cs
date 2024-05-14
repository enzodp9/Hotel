using Hotel.Services;
using Hotel.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestServices _guestServices;

        public GuestController(IGuestServices guestServices)
        {
            _guestServices = guestServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _guestServices.GetGuests();
                return Ok(users);
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
                var users = await _guestServices.GetGuestById(id);
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDTO guestDTO)
        {
            try
            {
                await _guestServices.CreateGuest(guestDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateGuestDTO guestDTO)
        {
            try
            {
                await _guestServices.UpdateGuest(id, guestDTO);
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
                await _guestServices.DeleteGuest(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }

        }

    }
}
