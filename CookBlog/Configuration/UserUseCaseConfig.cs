using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.DataAccess.Configuration
{
    public class UserUseCaseConfig : IEntityTypeConfiguration<UserUseCases>
    {
        public void Configure(EntityTypeBuilder<UserUseCases> builder)
        {
            builder.Property(x => x.UseCaseId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
