﻿using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Category);
            builder.HasOne(x => x.Author);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(160).HasColumnType("VARCHAR");
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Body).IsRequired().HasColumnType("TEXT");
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
            builder.Property(x => x.CreateDate).IsRequired().HasColumnType("DATETIME");
            builder.Property(x => x.LastUpdateDate).IsRequired().HasColumnType("DATETIME");
        }
    }
}
