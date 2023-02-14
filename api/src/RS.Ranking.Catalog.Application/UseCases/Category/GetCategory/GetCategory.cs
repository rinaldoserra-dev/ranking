using RS.Ranking.Catalog.Application.UseCases.Category.Common;
using RS.Ranking.Catalog.Domain.Repository;
using Flunt.Notifications;

namespace RS.Ranking.Catalog.Application.UseCases.Category.GetCategory
{
    public class GetCategory : Notifiable, IGetCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryModelOutput> Handle(GetCategoryInput input, CancellationToken cancellationToken)
        {
            // Fail Fast Validations
            input.Validate();
            if (input.Invalid)
            {
                AddNotifications(input);
                return null!;
            }

            var category = await _categoryRepository.Get(input.Id, cancellationToken);

            if(category == null)
            {
                AddNotification("Category", $"Category {input.Id} not found");
                return null!;
            }

            return CategoryModelOutput.FromCategory(category);
        }
    }
}
