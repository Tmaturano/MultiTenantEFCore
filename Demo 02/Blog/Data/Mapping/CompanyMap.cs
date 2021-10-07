using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);
                        
            builder.HasMany(x => x.Posts);
                        
            builder.Property(x => x.Name).IsRequired().HasMaxLength(160).HasColumnType("VARCHAR");
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR");
        }
    }
}
