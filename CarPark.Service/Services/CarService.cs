using CarPark.Core.Models;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Service.Services {
    public class CarService : Service<Car>, ICarService {
        public CarService(IUnitOfWork unitOfWork, IRepository<Car> repository) : base(unitOfWork, repository) {

        }

        public async Task<Car> GetWithParkByIdAsync(int carId) {
            return await _unitOfWork.Cars.GetWithParkByIdAsync(carId);
        }
    }
}