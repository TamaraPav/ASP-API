using AutoMapper;
using CookBlog.Application;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries.Recipes;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Recipes
{
    public class EfGetOneRecipeQuery : IGetOneRecipeQuery
    {

        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetOneRecipeQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 26;

        public string Name => "EfGetOneRecipeQuery";

        public ICollection<SingleCommentDto> parentComments { get; set; } = new List<SingleCommentDto>();

        RecipeClientDto IQuery<int, RecipeClientDto>.Execute(int search)
        {
            var post = context.Recipes.Find(search);

            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(Recipe));
            }

            var query = context.Recipes.Include(com => com.Comments)
                .Include(l => l.Likes)
                .Include(c => c.Category)
                .Include(u => u.User)
                .Where(p => p.Id == search)
                .First();



            var result = mapper.Map<RecipeClientDto>(query);

            return result;
        }
    }
}
