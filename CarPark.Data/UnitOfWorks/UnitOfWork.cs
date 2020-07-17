using CarPark.Core.Repositories;
using CarPark.Core.UnitOfWorks;
using CarPark.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Data.UnitOfWorks {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _context;
        private CarRepository _carRepository;
        private ParkRepository _parkRepository;
        public IParkRepository Park => _parkRepository=_parkRepository ?? new ParkRepository(_context);

        public ICarRepository Cars => _carRepository = _carRepository ?? new CarRepository(_context);

        public UnitOfWork(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public void Commit() {
            _context.SaveChanges();
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
