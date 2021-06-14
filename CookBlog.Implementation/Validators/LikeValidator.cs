using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Validators
{
    public class LikeValidator : AbstractValidator<LikeDto>
    {
        public LikeValidator()
        {
            RuleFor(x => x.RecipeId).NotEmpty();

            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Status)
                .NotEmpty()
                .Must(y => Enum.IsDefined(typeof(LikeStatus), y))
                .WithMessage("Status not valid");
        }
    }
}
