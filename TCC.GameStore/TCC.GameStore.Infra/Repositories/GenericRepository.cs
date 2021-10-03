using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Interfaces.Repositories;
using TCC.GameStore.Infra.Context;

namespace TCC.GameStore.Infra.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MainContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Query().SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public async Task Save() => await _dbContext.SaveChangesAsync();

        protected IQueryable<T> Query() => _dbSet.AsNoTracking().Where(entity => !entity.Deleted);
    }
}
