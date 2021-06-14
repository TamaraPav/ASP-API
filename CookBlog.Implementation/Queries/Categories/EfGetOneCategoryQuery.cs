using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries.Categories;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Categories
{
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;

        public EfGetOneCategoryQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 30;

        public string Name => "EfGetOneCategoryQuery";

        public SingleCategoryDto Execute(int search)
        {
            var findCat = context.Categories.Find(search);

            if (findCat == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            var query = context.Categories.Include(u => u.Recipes).Where(u => u.Id == search).First();

            var category = mapper.Map<SingleCategoryDto>(query);

            return category;
        }
    }
}
