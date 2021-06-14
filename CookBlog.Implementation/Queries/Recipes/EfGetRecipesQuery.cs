using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries;
using CookBlog.Application.Queries.Recipes;
using CookBlog.Application.Searches;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Recipes
{
    public class EfGetRecipesQuery : IGetRecipeQuery
    {

        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetRecipesQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 27;

        public string Name => "EfGetRecipesQuery";

        public PagedResponse<RecipeClientDto> Execute(RecipeSearch search)
        {
            var query = context.Recipes.Include(c => c.Category).Include(u => u.User).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<RecipeClientDto, Recipe>(search, mapper);
        }
    }
}
