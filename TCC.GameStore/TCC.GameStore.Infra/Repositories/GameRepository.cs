using System;
using System.Collections.Generic;
using System.Text;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Interfaces.Repositories;
using TCC.GameStore.Infra.Context;

namespace TCC.GameStore.Infra.Repositories
{
    public sealed class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(MainContext dbcontext) : base(dbcontext)
        {
        }
    }
}
