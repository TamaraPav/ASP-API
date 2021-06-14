using AutoMapper;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Recipes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBlog.Implementation.Commands.Recipes
{
    public class EfCreateRecipeCommand : ICreateRecipeCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateRecipeValidator validator;

        public EfCreateRecipeCommand(CookBlogContext context, IMapper mapper, CreateRecipeValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 15;

        public string Name => "EfCreateRecipeCommand";

        public void Execute(RecipeDto request)
        {
            validator.ValidateAndThrow(request);


            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Picture.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Picture.CopyTo(fileStream);
            }



            var post = mapper.Map<Recipe>(request);
            post.Picture = newFileName;
            context.Recipes.Add(post);
            context.SaveChanges();
        }
    }
}
