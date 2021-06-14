using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.DataAccess.Configuration
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(80);

            builder.Property(a => a.Description).IsRequired();

            builder.Property(a => a.LevelId).IsRequired();

            builder.Property(a => a.Picture).IsRequired();


            builder.HasMany(x => x.Comments)
                    .WithOne(c => c.Recipe)
                    .HasForeignKey(x => x.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
