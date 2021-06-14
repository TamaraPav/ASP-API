using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators.Recipes
{
    public class CreateRecipeValidator : AbstractValidator<RecipeDto>
    {
        public CreateRecipeValidator(CookBlogContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(x => !context.Recipes.Any(piece => piece.Name == x))
                    .WithMessage("Recipe with this name already exists.").MinimumLength(3);

            RuleFor(x => x.Description).MinimumLength(30);

            RuleFor(x => x.Picture)
               .NotEmpty();


            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .Must(catId => context.Categories.Any(p => p.Id == catId))
                .WithMessage("Category has to be valid.");

            RuleFor(x => x.LevelId)
                .NotEmpty()
                .Must(levelId => context.Levels.Any(p => p.Id == levelId))
                .WithMessage("Level has to be valid.");


        }
    }
}
