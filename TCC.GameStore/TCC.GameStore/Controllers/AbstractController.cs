using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TCC.GameStore.Domain.Exceptions;

namespace TCC.GameStore.Web.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public ActionResult HandleErrors(Exception ex)
        {
            if (ex is CustomValidationException)
            {
                return BadRequest(ex.Message);
            }

            if (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
