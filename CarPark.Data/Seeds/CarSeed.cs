using CarPark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Data.Seeds {
    class CarSeed:IEntityTypeConfiguration<Car> {
        private readonly int[] _ids;
        public CarSeed(int[] ids) {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Car> builder) {
            builder.HasData(
                new Car { Id = 1, EntryTime = DateTime.ParseExact("15/06/2015 13:45:00", "dd/MM/yyyy HH:mm:ss", null), Plaka = "01FYC01", ParkId = _ids[0] },
               
                    new Car { Id = 2, EntryTime = DateTime.ParseExact("15/06/2015 13:45:00", "dd/MM/yyyy HH:mm:ss", null), Plaka = "01FYC01", ParkId = _ids[0] }
                );
        }
    }
}
