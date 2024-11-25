using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Posts.Queries.GetUserPosts
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PictureId { get; set; }
        public bool IsCertified { get; set; }
    }
}