using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Categories
{
    public interface IGetOneCategoryQuery : IQuery<int, SingleCategoryDto>
    {
    }
}
