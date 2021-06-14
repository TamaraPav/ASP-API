using CookBlog.Application;
using CookBlog.Application.Commands.UserUseCase;
using CookBlog.Application.DataTransfer;
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
    public class UserUseCasesController : ControllerBase
    {

        private readonly IApplicationActor actor;
        private readonly IUseCaseExecutor executor;

        public UserUseCasesController(IApplicationActor actor, IUseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // POST: api/UserUseCases
        [HttpPost]
        public void Post([FromBody] UserUseCaseDto dto, [FromServices] ICreateUserUseCaseCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
