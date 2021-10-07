using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasKey(x => x.Id);
            
            builder
                .HasMany(x => x.Posts)
                .WithMany(x => x.Tags)
                .UsingEntity(x => x.ToTable("PostTag"));
                        
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
        }
    }
}
