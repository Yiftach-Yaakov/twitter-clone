
namespace TwitterClone.Domain.Events
{
    public class RePostCreatedEvent : DomainEvent
    {
        public RePost Item { get; private set; }

        public RePostCreatedEvent(RePost item)
        {
            Item = item;
        }
    }
}