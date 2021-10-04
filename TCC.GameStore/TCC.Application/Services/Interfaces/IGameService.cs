using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.GameModel;

namespace TCC.GameStore.Application.Services.Interfaces
{
    public interface IGameService
    {
        Task CreateGame(GameRequestModel requestModel);
        Task UpdateGame(int gameId, GameRequestModel requestModel);
        Task DeleteGame(int gameId);
        Task<GameResponseModel> GetById(int id);
        Task<IEnumerable<GameResponseModel>> GetAll();
    }
}
