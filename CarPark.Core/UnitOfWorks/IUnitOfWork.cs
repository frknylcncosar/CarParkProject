using CarPark.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.UnitOfWorks {
    public interface IUnitOfWork {
        IParkRepository Park { get; }
        ICarRepository Cars { get; }
        Task CommitAsync();
        void Commit();
    }
}
