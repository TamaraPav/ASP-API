using AutoMapper;
using CookBlog.Application.Commands.UserUseCase;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands
{
    public class EfUpdateUserUseCaseCommand : IUpdateUserUseCaseCommand
    {

        private CookBlogContext context;
        private IMapper mapper;
        private readonly UpdateUserUseCaseValidator validator;

        public EfUpdateUserUseCaseCommand(CookBlogContext context, IMapper mapper, UpdateUserUseCaseValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 4;

        public string Name => "Update Users Use Case";


        public void Execute(UserUseCaseDto request)
        {

        }
    }
}
