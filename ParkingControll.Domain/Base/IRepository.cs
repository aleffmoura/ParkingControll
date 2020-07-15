using ParkingControll.Infra.CrossCutting.Structs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControll.Domain.Base
{
    public interface IRepository<E> where E : Entity, new()
    {
        Task<Option<Exception, E>> CreateAsync(E entity);
        Task<Option<Exception, Unit>> UpdateAsync(E entity);
        Task<Option<Exception, E>> GetByIdAsync(Guid id);
        Option<Exception, IQueryable<E>> GetAll();
    }
}