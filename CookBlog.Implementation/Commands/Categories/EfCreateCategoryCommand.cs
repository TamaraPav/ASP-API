using AutoMapper;
using CookBlog.Application.Commands.Categories;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Categories
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateCategoryValidator validator;

        public EfCreateCategoryCommand(CookBlogContext context, IMapper mapper, CreateCategoryValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 5;

        public string Name => "EfCreateCategoryCommand";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var category = mapper.Map<Category>(request);
            context.Categories.Add(category);
            context.SaveChanges();


        }
    }
}
