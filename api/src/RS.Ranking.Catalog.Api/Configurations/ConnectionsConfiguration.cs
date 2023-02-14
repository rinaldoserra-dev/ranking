using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RS.Ranking.Catalog.Infra.Data.EF;

namespace RS.Ranking.Catalog.Api.Configurations
{
    public static class ConnectionsConfiguration
    {
        public static IServiceCollection AddAppConections(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbConnection(configuration);
            return services;
        }

        private static IServiceCollection AddDbConnection(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration
                .GetConnectionString("RankingDb");
            services.AddDbContext<RankingCatalogDbContext>(
                options => options.UseNpgsql(
                    connectionString,
                    x => {
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "ranking");
                        x.MigrationsAssembly("RS.Ranking.Catalog.Infra.Data.EF");
                    })
            );
            return services;
        }
    }
}
