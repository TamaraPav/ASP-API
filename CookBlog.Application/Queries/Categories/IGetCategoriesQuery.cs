using CookBlog.Application.DataTransfer;
using CookBlog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Categories
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch, PagedResponse<CategoryDto>>
    {
    }
}
