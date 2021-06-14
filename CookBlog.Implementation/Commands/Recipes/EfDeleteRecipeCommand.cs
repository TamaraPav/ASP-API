using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Recipes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Recipes
{
    public class EfDeleteRecipeCommand : IDeleteRecipeCommand
    {
        private readonly CookBlogContext context;
        private readonly DeleteRecipeValidator validator;

        public EfDeleteRecipeCommand(CookBlogContext context, DeleteRecipeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 16;

        public string Name => "EfDeleteRecipeCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var findPost = context.Recipes.Find(request);

            if (findPost == null)
            {
                throw new EntityNotFoundException(request, typeof(Recipe));
            }

            findPost.IsDeleted = true;
            findPost.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}

