﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Validators.Comments
{
    public class DeleteCommentValidator : AbstractValidator<int>
    {
        public DeleteCommentValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}