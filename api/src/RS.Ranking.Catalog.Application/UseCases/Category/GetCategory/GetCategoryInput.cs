using MediatR;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace RS.Ranking.Catalog.Application.UseCases.Category.GetCategory
{
    public class GetCategoryInput : Notifiable, IRequest<CategoryModelOutput>
    {
        public GetCategoryInput(Guid id)
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
