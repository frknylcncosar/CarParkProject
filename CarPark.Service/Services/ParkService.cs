using CarPark.Core.Models;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Service.Services {
    public class ParkService : Service<Park>, IParkService {
        public ParkService(IUnitOfWork unitOfWork, IRepository<Park> repository) : base(unitOfWork, repository) {
        }

        public async Task<Park> GetWithCarsByIdAsync(int parkId) {
            return await _unitOfWork.Park.GetWithCarsByIdAsync(parkId);
        }
    }
}
