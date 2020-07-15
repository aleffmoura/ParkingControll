using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Infra.CrossCutting.Structs;
using ParkingControll.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControll.Infra.Data.Features.Prices
{
    public class PriceRepository : IPriceRepository
    {
        private ParkingContext _context;
        public PriceRepository(ParkingContext parkingContext)
        {
            _context = parkingContext;
        }
        public async Task<Option<Exception, Price>> CreateAsync(Price entity)
        {
            EntityEntry<Price> newEntity = _context.Prices.Add(entity);

            await _context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public Option<Exception, IQueryable<Price>> GetAll()
            => Option.Run(() => _context.Prices.AsNoTracking().Where(a => !a.Removed));

        public async Task<Option<Exception, Price>> GetByIdAsync(Guid id)
        {
            Price entity = await _context.Prices.AsNoTracking().FirstOrDefaultAsync(a => !a.Removed && a.Id == id);

            if (entity == null)
                return new NotFoundException("Não foi encontrado um preços com valor de id informado.");

            return entity;
        }

        public async Task<Option<Exception, Price>> GetByDateAsync(DateTime period)
        {
            Price entity = await _context.Prices.AsNoTracking().FirstOrDefaultAsync(a => !a.Removed && (period >= a.Initial && period <= a.Final));

            if (entity == null)
                return new NotFoundException("Nçao foi encontrado preços com a data inicial informada.");

            return entity;
        }

        public async Task<Option<Exception, Unit>> UpdateAsync(Price entity)
        {
            _context.Prices.Update(entity);
            await _context.SaveChangesAsync();

            return Unit.Successful;
        }
    }
}
