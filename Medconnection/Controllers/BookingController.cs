using BLL.Interfaces;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medconnection.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)

        {
            _bookingRepository= bookingRepository;

        }

        [HttpGet("{DoctorId}")]
        public async Task<ActionResult<List<string>>>GetAvailableDays(int DoctorId)
        {
            List<string> availableDays = await _bookingRepository.GetAvailableDays(DoctorId);

            if (availableDays != null)
            {
                return Ok(availableDays);
            }

            return NotFound();
        }

    }
}
