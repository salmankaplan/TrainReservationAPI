using System.Collections.Generic;

namespace TrainReservationApi.Models
{
    public class TrainDetail
    {
        List<Train> Trains;
        public TrainDetail()
        {
            Trains = new List<Train>()
            {
                new Train()
                {
                    TrainName = "Antep",
                    Wagons = new List<Wagon>
                    {
                        new Wagon { WagonName = "Business", Capacity = 50, NumberofFullSeat = 34 },
                        new Wagon { WagonName = "Economy1", Capacity = 100, NumberofFullSeat = 75 },
                        new Wagon { WagonName = "Economy2", Capacity = 100, NumberofFullSeat = 30 },
                        new Wagon { WagonName = "Economy3", Capacity = 100, NumberofFullSeat = 70 }
                    }
                },
                new Train()
                {
                    TrainName = "İzmir",
                    Wagons = new List<Wagon>
                    {
                        new Wagon { WagonName = "Business", Capacity = 50, NumberofFullSeat = 20 },
                        new Wagon { WagonName = "Economy1", Capacity = 100, NumberofFullSeat = 80 },
                        new Wagon { WagonName = "Economy2", Capacity = 100, NumberofFullSeat = 60 },
                        new Wagon { WagonName = "Economy3", Capacity = 100, NumberofFullSeat = 70 }
                    }
                }
            };
        }
        public Train FindTrain(Train train)
        {
            return Trains.Find(x => x.TrainName == train.TrainName);
        }
    }
}
