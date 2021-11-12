using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Interfaces.Repositories;
using TCC.GameStore.Infra.Context;

namespace TCC.GameStore.Infra.Repositories
{
    public sealed class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await Query().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
