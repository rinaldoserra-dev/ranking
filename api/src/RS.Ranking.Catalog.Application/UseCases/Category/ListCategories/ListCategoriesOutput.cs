using RS.Ranking.Catalog.Application.Common;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;

namespace RS.Ranking.Catalog.Application.UseCases.Category.ListCategories
{
    public class ListCategoriesOutput : PaginatedListOutput<CategoryModelOutput>
    {
        public ListCategoriesOutput(
            int page, 
            int perPage, 
            int total, 
            IReadOnlyList<CategoryModelOutput> items) 
            : base(page, perPage, total, items)
        {
        }
    }
}
