using CookBlog.Application;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Recipes
{
    public class EfDeletePersonalRecipeCommand : IDeletePersonalRecipeCommand
    {
        private readonly CookBlogContext context;
        private readonly IApplicationActor actor;

        public EfDeletePersonalRecipeCommand(CookBlogContext context, IApplicationActor actor)
        {
            this.actor = actor;
            this.context = context;
        }
        public int Id => 17;

        public string Name => "EfDeletePersonalRecipeCommand";

        public void Execute(int request)
        {
            var findPost = context.Recipes.Find(request);

            if (findPost == null)
            {
                throw new EntityNotFoundException(request, typeof(Recipe));
            }

            if (actor.Id != findPost.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            findPost.IsDeleted = true;
            findPost.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
