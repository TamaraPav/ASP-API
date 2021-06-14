using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries;
using CookBlog.Application.Queries.Categories;
using CookBlog.Application.Searches;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Categories
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetCategoriesQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 29;

        public string Name => "EfGetCategoriesQuery";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CategoryDto, Category>(search, mapper);
        }
    }
}
