using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Ranking.Catalog.Domain.Entity;

namespace RS.Ranking.Catalog.Infra.Data.EF.Configurations
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Name)
                .HasMaxLength(255);
            builder.Property(category => category.Description)
                .HasMaxLength(10_000);
            builder.Property(c => c.CreatedAt).IsRequired().HasColumnType("date");
            builder.HasIndex(c => c.CreatedAt);

            builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Eletrônicos",
                    Description = "Descrição do eletrônico",
                    IsActive = true,
                    CreatedAt = new DateTime(2023,2,13)
                });
        }
    }
}
