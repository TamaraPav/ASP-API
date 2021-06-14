using AutoMapper;
using CookBlog.Application.Commands.UserUseCase;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands
{
    public class EfCreateUserUseCasesCommand : ICreateUserUseCaseCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateUserUseCaseValidator validator;

        public EfCreateUserUseCasesCommand(CookBlogContext context, IMapper mapper, CreateUserUseCaseValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 2;

        public string Name => "Create Users Use Case";

        public void Execute(UserUseCaseDto request)
        {
            validator.ValidateAndThrow(request);

            var useCase = mapper.Map<UserUseCases>(request);

            context.Add(useCase);
            context.SaveChanges();
        }
    }
}
