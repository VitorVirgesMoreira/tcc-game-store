using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.GameModel;
using TCC.GameStore.Application.Services.Interfaces;
using TCC.GameStore.Domain.Builders;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Exceptions;
using TCC.GameStore.Domain.Interfaces.Repositories;

namespace TCC.GameStore.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task CreateGame(GameRequestModel requestModel)
        {
            var game = GameBuild(requestModel);
            game.ValidateEntity();
            await _gameRepository.Create(game);
            await _gameRepository.Save();
        }

        public async Task UpdateGame(int gameId, GameRequestModel requestModel)
        {
            var gameBuild = GameBuild(requestModel);
            var game = await _gameRepository.GetById(gameId);
            game.UpdateGame(gameBuild);

            _gameRepository.Update(game);
            await _gameRepository.Save();
        }

        public async Task DeleteGame(int gameId)
        {
            var game = await _gameRepository.GetById(gameId);
            if (game == null)
            {
                throw new NotFoundException("Jogo não encontrado.");
            }

            game.Delete();

            _gameRepository.Update(game);
            await _gameRepository.Save();
        }

        public async Task<GameResponseModel> GetById(int id)
        {
            var game = await _gameRepository.GetById(id);
            if (game == null)
            {
                throw new NotFoundException("Jogo não encontrado.");
            }

            return new GameResponseModel(game.Id, game.Name, game.Developer, game.DateLaunch, game.Price, game.CreatedAt, game.UpdatedAt);
        }

        public async Task<IEnumerable<GameResponseModel>> GetAll()
        {
            var games = await _gameRepository.GetAll();
            if (games == null)
            {
                throw new NotFoundException("Jogos não encontrados.");
            }

            return games.Select(x => new GameResponseModel(x.Id, x.Name, x.Developer, x.DateLaunch, x.Price, x.CreatedAt, x.UpdatedAt));
        }

        private Game GameBuild(GameRequestModel model)
        {
            return new GameBuilder()
                .SetName(model.Name)
                .SetDeveloper(model.Developer)
                .SetDateLaunch(model.DateLaunch)
                .SetPrice(model.Price)
                .Build();
        }
    }
}
