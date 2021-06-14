using CookBlog.Application.DataTransfer;
using CookBlog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Users
{
    public interface IGetUsersQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {
    }
}
