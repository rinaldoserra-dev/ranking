using RS.Ranking.Catalog.Application.Interfaces;

namespace RS.Ranking.Catalog.Infra.Data.EF
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly RankingCatalogDbContext _context;

        public UnitOfWork(RankingCatalogDbContext context)
        {
            _context = context;
        }

        public Task Commit(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
