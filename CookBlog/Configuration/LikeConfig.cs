using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.DataAccess.Configuration
{
    public class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.RecipeId).IsRequired();

            builder.Property(x => x.Status).HasColumnType("bigint");
        }
    }
}
