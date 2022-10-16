using TrainReservationApi.Models;

namespace TrainReservationApi.Request
{
    public class ReservationRequest
    {
        public Train Train { get; set; }
        public int NumberofPassengers{ get; set; }
        public bool DifferentWagon { get; set; }
    }
}
