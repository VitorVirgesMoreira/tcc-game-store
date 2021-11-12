using System.Threading.Tasks;
using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
