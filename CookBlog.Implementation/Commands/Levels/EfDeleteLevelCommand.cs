
using CookBlog.Application.Commands.Level;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Levels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Levels
{
    public class EfDeleteLevelCommand : IDeleteLevelCommand
    {
        private readonly CookBlogContext context;
        private readonly DeleteLevelValidator validator;

        public EfDeleteLevelCommand(CookBlogContext context, DeleteLevelValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 9;

        public string Name => "EfDeleteLevelCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var level = context.Levels.Find(request);
            if (level == null)
            {
                throw new EntityNotFoundException(request, typeof(Level));
            }


            level.IsDeleted = true;
            level.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
