
namespace TwitterClone.Domain.Events
{
    public class FollowCreatedEvent : DomainEvent
    {
        public Follow Item { get; private set; }

        public FollowCreatedEvent(Follow item)
        {
            Item = item;    
        }
    }
}