using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries;
using CookBlog.Application.Queries.Levels;
using CookBlog.Application.Searches;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Levels
{
    public class EfGetLevelsQuery : IGetLevelsQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetLevelsQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 28;

        public string Name => "EfGetLevelsQuery";

        public PagedResponse<LevelDto> Execute(LevelSearch search)
        {
            var query = context.Levels.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<LevelDto, Level>(search, mapper);
        }
    }
}
