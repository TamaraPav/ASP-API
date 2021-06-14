using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators.Levels
{
    public class CreateLevelValidator : AbstractValidator<LevelDto>
    {
        public CreateLevelValidator(CookBlogContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .Must(c => !context.Levels.Any(ca => ca.Name == c))
                .WithMessage($"Level with this name already exists.");
        }
    }
}
