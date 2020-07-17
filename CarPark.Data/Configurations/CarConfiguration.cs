using CarPark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Data.Configurations {
    class CarConfiguration : IEntityTypeConfiguration<Car> {
        public void Configure(EntityTypeBuilder<Car> builder) {
            builder.HasKey(x => x.Id);//haskey primary key
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Plaka).IsRequired().HasMaxLength(15);
            builder.Property(x => x.EntryTime).IsRequired().HasColumnType("datetime2");

            builder.ToTable("Cars");
        }
    }
}
