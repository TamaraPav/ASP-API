using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(CookBlogContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .Must(c => !context.Categories.Any(ca => ca.Name == c))
                .WithMessage($"Category with this name already exists.");
        }

    }
}
