using System.Collections.Generic;
using TrainReservationApi.Models;

namespace TrainReservationApi.Response
{
    public class ReservationResponse
    {
        public bool ReservationAvailable { get; set; }
        public List<LayoutDetail> LayoutDetail { get; set; }

    }
}
