using CookBlog.API.Core;
using CookBlog.Application;
using CookBlog.Application.Email;
using CookBlog.DataAccess;
using CookBlog.Implementation.Commands;
using CookBlog.Implementation.Commands.Categories;
using CookBlog.Implementation.Commands.Comments;
using CookBlog.Implementation.Commands.Recipes;
using CookBlog.Implementation.Email;
using CookBlog.Implementation.Logging;
using CookBlog.Implementation.Queries;
using CookBlog.Implementation.Queries.Categories;
using CookBlog.Implementation.Queries.Levels;
using CookBlog.Implementation.Queries.Recipes;
using CookBlog.Implementation.Queries.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBlog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<CookBlogContext>();

            services.AddApplicationActor();
            services.AddJwt();
            services.AddUseCases();

            //Usecase logger and executor
            services.AddTransient<IUseCaseLogger, UseCaseLogger>();
            services.AddTransient<IUseCaseExecutor>();

            //Services
            services.AddTransient<JwtManager>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddHttpContextAccessor();

            //Add automapper
            services.AddAutoMapper(typeof(EfGetUseCaseLogsQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetLevelsQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreateUserUseCasesCommand).Assembly);
            services.AddAutoMapper(typeof(EfRegisterUserCommand).Assembly);
            services.AddAutoMapper(typeof(EfCreateCategoryCommand).Assembly);
            services.AddAutoMapper(typeof(EfGetOneUserQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetSingleUserClientQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetUsersClientQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetUsersQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreateRecipeCommand).Assembly);
            services.AddAutoMapper(typeof(EfGetOneCategoryQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreateCommentCommand));
            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cook Blog App", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
