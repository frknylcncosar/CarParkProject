using CarPark.Core.Models;
using CarPark.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Data.Repositories {
    class ParkRepository : Repository<Park>, IParkRepository {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ParkRepository(AppDbContext context) : base(context) {
        }

        public async Task<Park> GetWithCarsByIdAsync(int parkId) {
            return await _appDbContext.Parks.Include(x => x.Cars).SingleOrDefaultAsync(x => x.Id == parkId);
        }
    }
}
