using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.DTOs {
    public class ParkWithCarDto:ParkDto {
        public IEnumerable<CarDto> Cars { get; set; }
    }
}
