using Flunt.Notifications;
using RS.Ranking.Catalog.Application.Interfaces;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;
using RS.Ranking.Catalog.Domain.Repository;
using DomainEntity = RS.Ranking.Catalog.Domain.Entity;

namespace RS.Ranking.Catalog.Application.UseCases.Category.CreateCategory
{
    public class CreateCategory : Notifiable, ICreateCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategory(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryModelOutput> Handle(
            CreateCategoryInput input,
            CancellationToken cancellationToken)
        {
            var category = new DomainEntity.Category(
                input.Name,
                input.Description,
                input.IsActive);

            if (category.Invalid)
            {
                AddNotifications(category);
                return null!;
            }
            await _categoryRepository.Insert(category, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return CategoryModelOutput.FromCategory(category);
        }
    }
}
