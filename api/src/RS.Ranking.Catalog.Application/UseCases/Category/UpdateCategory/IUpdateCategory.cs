using MediatR;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;

namespace RS.Ranking.Catalog.Application.UseCases.Category.UpdateCategory
{
    public interface IUpdateCategory 
        : IRequestHandler<UpdateCategoryInput, CategoryModelOutput>
    {
    }
}
