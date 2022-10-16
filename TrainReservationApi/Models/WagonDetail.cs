using System.Collections.Generic;
using System.Linq;

namespace TrainReservationApi.Models
{
    public class WagonDetail
    {
        List<Wagon> Wagons;

        public WagonDetail()
        {
            Wagons = new List<Wagon>
            {
              new Wagon { WagonName = "Business", Capacity = 50, NumberofFullSeat = 30 },
              new Wagon { WagonName = "Economy1", Capacity = 100, NumberofFullSeat = 75 },
              new Wagon { WagonName = "Economy2", Capacity = 100, NumberofFullSeat = 60 },
              new Wagon { WagonName = "Economy3", Capacity = 100, NumberofFullSeat = 70 }
            };
        }

        public bool ControlWagon(List<Wagon> wagons)
        {
            foreach (var wagon in wagons)
            {
                bool exist = Wagons.Any(x => x.WagonName == wagon.WagonName);
                if (exist == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
