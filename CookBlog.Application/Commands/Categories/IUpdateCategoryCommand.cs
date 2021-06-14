using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Commands.Categories
{
    public interface IUpdateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
