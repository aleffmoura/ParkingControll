using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.CrossCutting.Structs;
using ParkingControll.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControll.Infra.Data.Features.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private ParkingContext _context;
        public VehicleRepository(ParkingContext parkingContext)
        {
            _context = parkingContext;
        }
        public async Task<Option<Exception, Vehicle>> CreateAsync(Vehicle entity)
        {
            EntityEntry<Vehicle> newEntity = _context.Vehicles.Add(entity);

            await _context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public Option<Exception, IQueryable<Vehicle>> GetAll()
            => Option.Run(() => _context.Vehicles.AsNoTracking().Where(a => !a.Removed));

        public Option<Exception, IQueryable<Vehicle>> GetAll(DateTime period)
            => Option.Run(() => _context.Vehicles.Where(a => !a.Removed && a.CameIn <= period));

        public async Task<Option<Exception, Vehicle>> GetByIdAsync(Guid id)
        {
            Vehicle entity = await _context.Vehicles.AsNoTracking().FirstOrDefaultAsync(a => !a.Removed && a.Id == id);

            if (entity == null)
                return new NotFoundException("Não foi encontrado um carro com valor de id informado.");

            return entity;
        }

        public async Task<Option<Exception, Vehicle>> GetByPlateAsync(string plate)
        {
            Vehicle entity = await _context.Vehicles.AsNoTracking().FirstOrDefaultAsync(a => !a.Removed && a.Plate.Equals(plate, StringComparison.OrdinalIgnoreCase));

            if (entity == null)
                return new NotFoundException("Não foi encontrado um carro com valor da placa informada.");

            return entity;
        }

        public async Task<Option<Exception, Unit>> UpdateAsync(Vehicle entity)
        {
            _context.Vehicles.Update(entity);
            await _context.SaveChangesAsync();

            return Unit.Successful;
        }
    }
}
