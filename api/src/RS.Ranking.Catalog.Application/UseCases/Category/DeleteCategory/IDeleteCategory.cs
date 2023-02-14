using MediatR;

namespace RS.Ranking.Catalog.Application.UseCases.Category.DeleteCategory
{
    public interface IDeleteCategory : IRequestHandler<DeleteCategoryInput>
    {
    }
}
