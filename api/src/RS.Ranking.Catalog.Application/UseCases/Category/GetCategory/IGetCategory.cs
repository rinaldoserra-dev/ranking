using MediatR;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;

namespace RS.Ranking.Catalog.Application.UseCases.Category.GetCategory
{
    public interface IGetCategory: IRequestHandler<GetCategoryInput, CategoryModelOutput> 
    { }
}
