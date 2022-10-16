using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainReservationApi.Models
{
    public class Train
    {
        public string TrainName { get; set; } 
        public List<Wagon> Wagons { get; set; } 
    }
}
