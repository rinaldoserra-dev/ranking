using MediatR;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;

namespace RS.Ranking.Catalog.Application.UseCases.Category.CreateCategory
{
    public interface ICreateCategory : IRequestHandler<CreateCategoryInput, CategoryModelOutput>
    { }
}
