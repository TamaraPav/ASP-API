using CookBlog.Application.Commands.User;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Users
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {

        private readonly CookBlogContext context;

        public EfDeleteUserCommand(CookBlogContext context)
        {
            this.context = context;
        }
        public int Id => 32;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            var user = context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Entities.User));
            }

            user.DeletedAt = DateTime.Now;
            user.IsDeleted = true;

            context.SaveChanges();
        }
    }
}
