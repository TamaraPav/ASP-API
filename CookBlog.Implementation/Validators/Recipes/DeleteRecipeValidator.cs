using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Validators.Recipes
{
    public class DeleteRecipeValidator : AbstractValidator<int>
    {
        public DeleteRecipeValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
