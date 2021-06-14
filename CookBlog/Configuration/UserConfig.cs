using CookBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.DataAccess.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(15);
            builder.Property(x => x.LastName).HasMaxLength(20);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(u => u.UserUseCases)
                .WithOne(uuc => uuc.User)
                .HasForeignKey(uuc => uuc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Recipes)
                .WithOne(u => u.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comments)
                   .WithOne(c => c.User)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
