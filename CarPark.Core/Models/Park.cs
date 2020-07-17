using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarPark.Core.Models {
    public class Park {

        public Park() {
            Cars = new Collection<Car>();
        }
        public int Id { get; set; }

        public int ParkingSpace { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
