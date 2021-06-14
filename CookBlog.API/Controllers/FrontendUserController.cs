using CookBlog.Application;
using CookBlog.Application.Queries.Users;
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
    public class FrontendUserController : ControllerBase
    {

        private readonly IUseCaseExecutor executor;

        public FrontendUserController(IUseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/FrontendUser
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersClientQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/FrontendUser/5
        [HttpGet("{id}", Name = "GetClientUsers")]
        public IActionResult Get(int id, [FromServices] IGetOneUserClientQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }
    }
}
