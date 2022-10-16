using System.Collections.Generic;
using System.Linq;
using TrainReservationApi.Models;
using TrainReservationApi.Request;
using TrainReservationApi.Response;

namespace TrainReservationApi.Business
{
    public class ReservationManager
    {
        TrainDetail _trainDetail;
        WagonDetail _wagonDetail;
        public ReservationManager()
        {
            _trainDetail = new TrainDetail();
            _wagonDetail = new WagonDetail();
        }
        public ReservationResponse TrainReservation(ReservationRequest reservationRequest)
        {
            if (TrainControl(reservationRequest) == false || WagonControl(reservationRequest) == false || CapacityControl(reservationRequest) == false)
            {
                return new ReservationResponse { ReservationAvailable = false, LayoutDetail = new List<LayoutDetail>() };
            }

            if (reservationRequest.DifferentWagon == true)
            {
                List<LayoutDetail> layoutList = new List<LayoutDetail>();
                var passengersNum = reservationRequest.NumberofPassengers;

                foreach (var wagon in reservationRequest.Train.Wagons)
                {
                    LayoutDetail layoutDetail = new LayoutDetail { WagonName = wagon.WagonName, NumberofPassenger = 0 };
                    for (int i = 0; i < passengersNum; i++)
                    {
                        decimal occupancy = (wagon.NumberofFullSeat / (decimal)wagon.Capacity) * 100;
                        if (occupancy >= 70)
                            break;
                        wagon.NumberofFullSeat += 1;
                        layoutDetail.NumberofPassenger += 1;
                        reservationRequest.NumberofPassengers -= 1;
                    }
                    if (layoutDetail.NumberofPassenger != 0)
                    {
                        layoutList.Add(layoutDetail);
                        passengersNum = reservationRequest.NumberofPassengers;
                    }
                }
                if (reservationRequest.NumberofPassengers == 0)
                {
                    return new ReservationResponse
                    {
                        ReservationAvailable = true,
                        LayoutDetail = layoutList
                    };
                }
                return new ReservationResponse { ReservationAvailable = false, LayoutDetail = new List<LayoutDetail>() };
            }
            else
            {
                foreach (var wagon in reservationRequest.Train.Wagons)
                {
                    decimal occupancy = ((wagon.NumberofFullSeat + reservationRequest.NumberofPassengers) / (decimal)wagon.Capacity) * 100;
                    if (occupancy >= 70)
                        continue;
                    return new ReservationResponse
                    {
                        ReservationAvailable = true,
                        LayoutDetail = new List<LayoutDetail> {
                            new LayoutDetail { WagonName = wagon.WagonName, NumberofPassenger = reservationRequest.NumberofPassengers }
                        }
                    };
                }
                return new ReservationResponse { ReservationAvailable = false, LayoutDetail = new List<LayoutDetail>() };
            }
        }
        public bool TrainControl(ReservationRequest reservationRequest)
        {
            Train train = _trainDetail.FindTrain(reservationRequest.Train);
            if (train == null)
            {
                return false;
            }
            return true;
        }
        public bool WagonControl(ReservationRequest reservationRequest)
        {
            return _wagonDetail.ControlWagon(reservationRequest.Train.Wagons);
        }
        public bool CapacityControl(ReservationRequest reservationRequest)
        {
            var wagonList = reservationRequest.Train.Wagons.ToList();
            foreach (var wagon in wagonList)
            {
                GetWagonInfo(wagon, reservationRequest);
                decimal occupancy = (wagon.NumberofFullSeat / (decimal)wagon.Capacity) * 100;
                if (occupancy >= 70)
                {
                    reservationRequest.Train.Wagons.Remove(wagon);
                }
            }
            if (reservationRequest.Train.Wagons == null)
            {
                return false;
            }
            return true;
        }
        public void GetWagonInfo(Wagon wagon, ReservationRequest reservationRequest)
        {
            var wagonName = wagon.WagonName;
            var NewWagonList = _trainDetail.FindTrain(reservationRequest.Train).Wagons.Where(x => x.WagonName == wagonName).ToList();
            foreach (var item in NewWagonList)
            {
                wagon.Capacity = item.Capacity;
                wagon.NumberofFullSeat = item.NumberofFullSeat;
            };
        }
    }
}
