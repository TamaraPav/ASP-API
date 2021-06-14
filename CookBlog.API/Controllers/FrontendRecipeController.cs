using CookBlog.Application;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontendRecipeController : ControllerBase
    {
        private readonly IUseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public FrontendRecipeController(IUseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // PUT: api/FrontendRecipe/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] RecipeDto dto, [FromServices] IUpdatePersonalRecipeCommand command)
        {
            dto.UserId = actor.Id;
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePersonalRecipeCommand command)
        {

            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
