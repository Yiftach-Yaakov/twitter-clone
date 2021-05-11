using TwitterClone.Application.Common.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Posts.Queries.GetPosts
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
    }
}