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

namespace CookBlog.Implementation.Queries.Recipes
{
    public class EfGetOneUserQuery : IGetOneUserQuery
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public EfGetOneUserQuery(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 22;

        public string Name => "EfGetOneUserQuery";

        public SingleUserDto Execute(int search)
        {
            var u = context.Users.Find(search);

            if (u == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var query = context.Users.Include(u => u.UserUseCases).Include(u => u.Recipes).ThenInclude(l => l.Level).Include(u => u.Recipes).ThenInclude(c => c.Category).Where(u => u.Id == search).First();

            var user = mapper.Map<SingleUserDto>(query);

            return user;
        }
    }
}
