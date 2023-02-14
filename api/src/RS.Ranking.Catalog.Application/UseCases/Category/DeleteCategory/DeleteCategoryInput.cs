using MediatR;
using Flunt.Notifications;
using Flunt.Validations;

namespace RS.Ranking.Catalog.Application.UseCases.Category.DeleteCategory
{
    public class DeleteCategoryInput : Notifiable, IRequest
    {
        public DeleteCategoryInput(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotEmpty(Id, "Id", "O Id é obrigatório")
           );
        }
    }
}
