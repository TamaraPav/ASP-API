using CookBlog.Application.Commands.UserUseCase;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands
{
    public class EfDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {

        private readonly CookBlogContext context;

        public EfDeleteUserUseCaseCommand(CookBlogContext context)
        {
            this.context = context;
        }
        public int Id => 3;

        public string Name => "Delete Users Use Case";

        public void Execute(int request)
        {
            var useCase = context.UserUseCases.Find(request);

            if (useCase == null)
            {
                throw new EntityNotFoundException(request, typeof(UserUseCases));
            }

            context.UserUseCases.Remove(useCase);

            context.SaveChanges();
        }
    }
}
