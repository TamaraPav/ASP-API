using CookBlog.Application;
using CookBlog.Application.Commands.User;
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
    public class RegisterController : ControllerBase
    {
        private readonly IUseCaseExecutor executor;

        public RegisterController(IUseCaseExecutor executor)
        {
            this.executor = executor;
        }
        // POST: api/Register
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto,
            [FromServices] IRegisterUserCommand command
            )
        {
            executor.ExecuteCommand(command, dto);
        }

    }
}
