using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Core.Models {
    public class Car {
        public int Id { get; set; }
        public string Plaka { get; set; }
        public int ParkId { get; set; }
        public DateTime EntryTime { get; set; }
        public virtual Park Park { get; set; }
    }
}
