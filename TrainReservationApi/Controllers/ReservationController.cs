using Microsoft.AspNetCore.Mvc;
using TrainReservationApi.Business;
using TrainReservationApi.Request;
using TrainReservationApi.Response;

namespace TrainReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationManager _reservationManager;

        public ReservationController()
        {
            _reservationManager = new ReservationManager();
        }
        [HttpPost]
        public ReservationResponse TrainReservation([FromBody] ReservationRequest request)
        {
            return _reservationManager.TrainReservation(request);
        }
    }
}
