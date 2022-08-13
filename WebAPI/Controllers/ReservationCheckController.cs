using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationCheckController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationCheckController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("Check")]
        public async Task<IActionResult> GetTrainsAsync(ReservationRequest request)
        {
            var result = await _reservationService.CheckReservation(request);
            return Ok(result);
        }
    }
}
