using AutoMapper;
using CookBlog.Application.Commands.Categories;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Categories
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private CookBlogContext context;
        private IMapper mapper;
        private readonly UpdateCategoryValidator validator;

        public EfUpdateCategoryCommand(CookBlogContext context, IMapper mapper, UpdateCategoryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 7;

        public string Name => "EfUpdateCategoryCommand";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);
            var findCat = context.Categories.Find(request.Id);
            if (findCat == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            var category = context.Categories.Where(x => x.Id == request.Id).First();

            mapper.Map(request, category);
            context.SaveChanges();
        }
    }
}
