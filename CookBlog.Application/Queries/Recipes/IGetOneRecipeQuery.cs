using CookBlog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Recipes
{
    public interface IGetOneRecipeQuery : IQuery<int, RecipeClientDto>
    {
    }
}
