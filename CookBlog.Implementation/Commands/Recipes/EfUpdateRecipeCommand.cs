using AutoMapper;
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
    public class EfUpdateRecipeCommand : IUpdateRecipeCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateRecipeValidator validator;

        public EfUpdateRecipeCommand(CookBlogContext context, IMapper mapper, CreateRecipeValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 18;

        public string Name => "EfUpdateRecipeCommand";

        public void Execute(RecipeDto request)
        {
            validator.ValidateAndThrow(request);
            var findPost = context.Recipes.Find(request.Id);
            if (findPost == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Recipe));
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

