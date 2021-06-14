using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Queries.Users;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Queries.Users
{
    public class EfGetSingleUserClientQuery : IGetOneUserClientQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetSingleUserClientQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 23;

        public string Name => "EfGetSingleUserClientQuery";

        public SingleUserClientDto Execute(int search)
        {
            var u = context.Users.Find(search);

            if (u == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var query = context.Users.Include(u => u.Recipes).Where(u => u.Id == search).First();

            var user = mapper.Map<SingleUserClientDto>(query);

            return user;
        }
    }
}
