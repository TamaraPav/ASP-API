using CookBlog.Application;
using CookBlog.Application.Commands.Level;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries.Levels;
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
    public class LevelController : ControllerBase
    {
        private readonly IUseCaseExecutor executor;

        public LevelController(IUseCaseExecutor executor)
        {
            this.executor = executor;
        }
        // GET: api/Level
        [HttpGet]
        public IActionResult Get([FromQuery] LevelSearch search, [FromServices] IGetLevelsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }


        // POST: api/Level
        [HttpPost]
        public IActionResult Post([FromBody] LevelDto dto, [FromServices] ICreateLevelCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Level/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LevelDto dto, [FromServices] IUpdateLevelCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLevelCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
