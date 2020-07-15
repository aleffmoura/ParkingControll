using ParkingControll.Domain.Base;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControll.Domain.Features.Vehicles
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Option<Exception, Vehicle>> GetByPlateAsync(string plate);
        Option<Exception, IQueryable<Vehicle>> GetAll(DateTime period);
    }
}
