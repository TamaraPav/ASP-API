using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators.Comments
{
    public class CreateCommentValidator : AbstractValidator<CommentDto>
    {
        public CreateCommentValidator(CookBlogContext context)
        {
            RuleFor(x => x.Text).NotEmpty();

            RuleFor(x => x.RecipeId)
                .NotEmpty()
                .Must(pieceId => context.Recipes.Any(p => p.Id == pieceId))
                .WithMessage("This recipe doesn't exist.");
        }
    }
}
