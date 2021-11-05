using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.GameModel;
using TCC.GameStore.Application.Services.Interfaces;

namespace TCC.GameStore.Web.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : AbstractController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameRequestModel requestModel)
        {
            try
            {
                await _gameService.CreateGame(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GameRequestModel requestModel)
        {
            try
            {
                await _gameService.UpdateGame(id, requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPut]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _gameService.DeleteGame(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _gameService.GetById(id));
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _gameService.GetAll());
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
