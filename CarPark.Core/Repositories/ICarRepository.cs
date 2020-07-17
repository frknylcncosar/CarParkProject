using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Repositories {
    public interface ICarRepository:IRepository<Car> {
        Task<Car> GetWithParkByIdAsync(int carId);
    }
}
