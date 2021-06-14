using AutoMapper;
using CookBlog.Application;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Queries;
using CookBlog.Application.Queries.Users;
using CookBlog.Application.Searches;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Users
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetUsersQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 24;

        public string Name => "EfGetUsersQuery";

        PagedResponse<UserDto> IQuery<UserSearch, PagedResponse<UserDto>>.Execute(UserSearch search)
        {
            var query = context.Users.Include(x => x.UserUseCases).AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }


            return query.Paged<UserDto, User>(search, mapper);
        }
    }
}
