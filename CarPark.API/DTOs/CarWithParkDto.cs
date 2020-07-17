using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.DTOs {
    public class CarWithParkDto:CarDto {
        public ParkDto Park { get; set; }
    }
}
