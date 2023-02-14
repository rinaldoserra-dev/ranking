using RS.Ranking.Catalog.Application.UseCases.Category.CreateCategory;
using MediatR;
using RS.Ranking.Catalog.Application.Interfaces;
using RS.Ranking.Catalog.Domain.Repository;
using RS.Ranking.Catalog.Infra.Data.EF.Repositories;
using RS.Ranking.Catalog.Infra.Data.EF;

namespace RS.Ranking.Catalog.Api.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(
            this IServiceCollection services
        )
        {
            services.AddMediatR(typeof(CreateCategory));
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
