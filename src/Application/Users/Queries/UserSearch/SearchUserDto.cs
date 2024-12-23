using System.Linq;
using AutoMapper;
using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Users.Queries.UserSearch
{
    public class SearchUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PictureId { get; set; }
        public bool FollowedByMe { get; set; }

       private class Mapping : Profile
        {
            public Mapping()
            {
                var applicationUserId = "";

                CreateMap<User, SearchUserDto>()
                .ForMember(
                    dto => dto.FollowedByMe, 
                    opt => opt.MapFrom(u => !string.IsNullOrWhiteSpace(applicationUserId) 
                        && u.Followers.Any(f => f.Follower.ApplicationUserId == applicationUserId)));;
            }
        }
    }
}