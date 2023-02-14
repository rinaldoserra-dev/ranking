using Flunt.Notifications;

namespace RS.Ranking.Catalog.Domain.SeedWork
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }

        protected Entity() => Id = Guid.NewGuid();
    }
}
