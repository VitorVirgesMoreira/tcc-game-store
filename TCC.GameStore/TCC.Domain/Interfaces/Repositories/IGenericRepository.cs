using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Save();
    }
}
