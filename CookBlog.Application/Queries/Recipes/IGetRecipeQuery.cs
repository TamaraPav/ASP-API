using CookBlog.Application.DataTransfer;
using CookBlog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Queries.Recipes
{
    public interface IGetRecipeQuery : IQuery<RecipeSearch, PagedResponse<RecipeClientDto>>
    {
    }
}
