using CookBlog.Application.Commands.Categories;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Categories
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {

        private readonly CookBlogContext context;
        private readonly DeleteCategoryValidator validator;

        public EfDeleteCategoryCommand(CookBlogContext context, DeleteCategoryValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 6;

        public string Name => "EfDeleteCategoryCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var findCat = context.Categories.Find(request);

            if (findCat == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            findCat.IsDeleted = true;
            findCat.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
