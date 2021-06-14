using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries;
using CookBlog.Application.Searches;
using CookBlog.DataAccess;
using CookBlog.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetUseCaseLogsQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 21;

        public string Name => "Search Audit Log";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {

                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));

            }
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.DateStart) || !string.IsNullOrWhiteSpace(search.DateStart) ||
               !string.IsNullOrEmpty(search.DateEnd) || !string.IsNullOrWhiteSpace(search.DateEnd))
            {

                DateTime startDate = Convert.ToDateTime(search.DateStart);
                DateTime endDate = Convert.ToDateTime(search.DateEnd);

                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
            }

            return query.Paged<UseCaseLogDto, Domain.Entities.UseCaseLog>(search, mapper);
        }
    }
}
