using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarPark.Core.Models;

namespace CarPark.Core.Repositories {
    public interface IParkRepository:IRepository<Park> {
        Task<Park> GetWithCarsByIdAsync(int parkId);
    }
}
