using System.Collections.Generic;

namespace TwitterClone.Domain.Entities
{
    public class Conversation : AuditableEntity
    {
        public int Id { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}