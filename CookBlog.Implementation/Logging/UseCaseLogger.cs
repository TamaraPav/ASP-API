using AutoMapper;
using CookBlog.Application;
using CookBlog.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Logging
{
    public class UseCaseLogger : IUseCaseLogger
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        public UseCaseLogger(CookBlogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            context.UseCaseLogs.Add(new Domain.Entities.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name

            });

            context.SaveChanges();

        }
    }
}
