using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Commands.Likes
{
    public interface ILikePostCommand : ICommand<LikeDto>
    {
    }
}
