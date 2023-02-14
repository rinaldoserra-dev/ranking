using RS.Ranking.Catalog.Domain.Entity;
using RS.Ranking.Catalog.Domain.SeedWork;
using RS.Ranking.Catalog.Domain.SeedWork.SearchableRepository;

namespace RS.Ranking.Catalog.Domain.Repository
{
    public interface ICategoryRepository
        : IGenericRepository<Category>,
        ISearchableRepository<Category>
    {
    }
}
