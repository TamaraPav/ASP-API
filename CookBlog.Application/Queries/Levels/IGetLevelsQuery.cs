using CookBlog.Application.DataTransfer;
using CookBlog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Levels
{
    public interface IGetLevelsQuery : IQuery<LevelSearch, PagedResponse<LevelDto>>
    {
    }
}
