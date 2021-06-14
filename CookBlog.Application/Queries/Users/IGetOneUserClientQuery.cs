using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Users
{
    public interface IGetOneUserClientQuery : IQuery<int, SingleUserClientDto>
    {
    }
}
