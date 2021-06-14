using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Validators.Levels
{
    public class DeleteLevelValidator : AbstractValidator<int>
    {
        public DeleteLevelValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
