using CookBlog.Application;
using CookBlog.Application.Queries;
using CookBlog.Application.Searches;
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
    public class UseCaseLogsController : ControllerBase
    {

        private readonly IApplicationActor actor;
        private readonly IUseCaseExecutor executor;

        public UseCaseLogsController(IApplicationActor actor, IUseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/UseCaseLogs
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
    }
}
