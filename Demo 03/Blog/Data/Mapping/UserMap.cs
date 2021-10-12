using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("UserRole")); ;

            builder.Property(x => x.Name).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR");
            builder.Property(x => x.Bio).IsRequired().HasColumnType("TEXT");
            builder.Property(x => x.Image).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR");
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
        }
    }
}
