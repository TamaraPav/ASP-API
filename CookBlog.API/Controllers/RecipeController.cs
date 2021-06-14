using CookBlog.Application;
using CookBlog.Application.Commands.Likes;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries.Recipes;
using CookBlog.Application.Searches;
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
    public class RecipeController : ControllerBase
    {
        private readonly IUseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public RecipeController(IUseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        [HttpPost]
        [Route("like")]
        public IActionResult Like([FromBody] LikeDto request, [FromServices] ILikePostCommand command)
        {
            request.UserId = actor.Id;

            executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }
        // GET: api/Recipe/
        [HttpGet]
        public IActionResult Get([FromQuery] RecipeSearch search, [FromServices] IGetRecipeQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Recipe/5
        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult Get(int id, [FromServices] IGetOneRecipeQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Recipe
        [HttpPost]
        public IActionResult Post([FromForm] RecipeDto dto, [FromServices] ICreateRecipeCommand command)
        {
            dto.UserId = actor.Id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] RecipeDto dto, [FromServices] IUpdateRecipeCommand command)
        {
            dto.Id = id;
            dto.UserId = actor.Id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRecipeCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
