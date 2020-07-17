using CarPark.Core.Models;
using CarPark.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Data.Repositories {
   public class CarRepository : Repository<Car>, ICarRepository {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CarRepository(AppDbContext context) : base(context) {
        }

        public async Task<Car> GetWithParkByIdAsync(int carId) {
            return await _appDbContext.Cars.Include(x => x.Park).SingleOrDefaultAsync(x => x.Id == carId);
            //?
        }
    }
}
