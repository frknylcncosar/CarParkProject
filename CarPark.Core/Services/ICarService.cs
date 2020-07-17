using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Services {
    public interface ICarService:IService<Car> {
        Task<Car> GetWithParkByIdAsync(int carId);

        
    }
}
