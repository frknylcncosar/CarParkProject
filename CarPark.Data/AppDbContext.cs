using CarPark.Core.Models;
using CarPark.Data.Configurations;
using CarPark.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Data {
    public class AppDbContext:DbContext {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {

        }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //tablo oluşmadan önce çalışacak metod
            //pk vs belirttiğimiz yer
            //burayı temiz tutacağız 
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ParkConfiguration());
            modelBuilder.ApplyConfiguration(new CarSeed(new int[] {1,2}));
            modelBuilder.ApplyConfiguration(new ParkSeed(new int[] {1,2}));
        }
    }
}
