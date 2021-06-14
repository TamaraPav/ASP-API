using AutoMapper;
using CookBlog.Application;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Recipes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Recipes
{
    public class EfUpdatePersonalRecipeCommand : IUpdatePersonalRecipeCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateRecipeValidator validator;
        private readonly IApplicationActor actor;

        public EfUpdatePersonalRecipeCommand(CookBlogContext context, IMapper mapper, CreateRecipeValidator validator, IApplicationActor actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
            this.actor = actor;
        }
        public int Id => 19;

        public string Name => "EfUpdatePersonalRecipeCommand";

        public void Execute(RecipeDto request)
        {
            validator.ValidateAndThrow(request);

            var findPost = context.Recipes.Find(request.Id);
            if (findPost == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Recipe));
            }

            if (actor.Id != findPost.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            var post = context.Recipes.Where(x => x.Id == request.Id).First();

            var newFileName = "";

            if (request.Picture != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(request.Picture.FileName);

                newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.Picture.CopyTo(fileStream);
                }
            }
            else
            {
                newFileName = post.Picture;
            }

            mapper.Map(request, post);
            post.Picture = newFileName;
            context.SaveChanges();

        }
    }
}
