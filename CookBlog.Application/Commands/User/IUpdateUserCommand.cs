using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Commands.User
{
    public interface IUpdateUserCommand : ICommand<UserDto>
    {
    }
}
