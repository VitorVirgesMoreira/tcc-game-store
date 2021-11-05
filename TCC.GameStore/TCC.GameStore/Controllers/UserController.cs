using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.UserModel;
using TCC.GameStore.Application.Services.Interfaces;

namespace TCC.GameStore.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : AbstractController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestModel requestModel)
        {
            try
            {
                await _userService.CreateUser(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserRequestModel requestModel)
        {
            try
            {
                await _userService.UpdateUser(id, requestModel);
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
                await _userService.DeleteUser(id);
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
                return Ok(await _userService.GetById(id));
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
                return Ok(await _userService.GetAll());
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
