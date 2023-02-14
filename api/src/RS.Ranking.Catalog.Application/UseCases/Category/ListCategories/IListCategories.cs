using MediatR;

namespace RS.Ranking.Catalog.Application.UseCases.Category.ListCategories
{
    public interface IListCategories 
        : IRequestHandler<ListCategoriesInput, ListCategoriesOutput>
    {
    }
}
