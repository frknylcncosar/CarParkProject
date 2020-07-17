using CarPark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Data.Configurations {
    class ParkConfiguration : IEntityTypeConfiguration<Park> {
        public void Configure(EntityTypeBuilder<Park> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Park");

        }
    }
}
