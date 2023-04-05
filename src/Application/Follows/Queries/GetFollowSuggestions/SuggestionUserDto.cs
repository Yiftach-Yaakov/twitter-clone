using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Follows.Queries.GetFollowSuggestions
{
    public class SuggestionUserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PictureId { get; set; }
        public bool IsCertified { get; set; }
    }
}