using CarPark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Data.Seeds {
    class ParkSeed : IEntityTypeConfiguration<Park> {
        private readonly int[] _ids;
        public ParkSeed(int[] ids) {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Park> builder) {
            builder.HasData(new Park { Id = _ids[0] });
        }
    }
}
