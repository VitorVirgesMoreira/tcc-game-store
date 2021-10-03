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
    }
}
