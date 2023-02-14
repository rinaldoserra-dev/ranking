using MediatR;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace RS.Ranking.Catalog.Application.UseCases.Category.UpdateCategory
{
    public class UpdateCategoryInput: Notifiable, IRequest<CategoryModelOutput>
    {
        public UpdateCategoryInput(
            Guid id, 
            string name, 
            string? description = null, 
            bool? isActive = null)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotEmpty(Id, "Id", "O Id é obrigatório")
           );
        }
    }
}
