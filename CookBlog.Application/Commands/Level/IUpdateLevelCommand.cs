using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Commands.Level
{
    public interface IUpdateLevelCommand : ICommand<LevelDto>
    {
    }
}
