using ParkingControll.Domain.Base;
using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Threading.Tasks;

namespace ParkingControll.Domain.Features.PriceAggregation
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Option<Exception, Price>> GetByDateAsync(DateTime initial);
    }
}
