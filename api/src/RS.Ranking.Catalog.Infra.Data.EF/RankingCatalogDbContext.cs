using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using RS.Ranking.Catalog.Domain.Entity;
using RS.Ranking.Catalog.Infra.Data.EF.Configurations;

namespace RS.Ranking.Catalog.Infra.Data.EF
{
    public class RankingCatalogDbContext
        : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public RankingCatalogDbContext(DbContextOptions<RankingCatalogDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ranking");
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}