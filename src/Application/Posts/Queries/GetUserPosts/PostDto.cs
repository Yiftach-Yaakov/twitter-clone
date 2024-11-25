using System;
using System.Linq;
using AutoMapper;
using TwitterClone.Application.Common.Mappings;

namespace TwitterClone.Application.Posts.Queries.GetUserPosts
{
    public class PostDto : IMapFrom<Post>
    {
        public int Id { get; set; }
        public int? AnswerToId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public UserDto CreatedBy { get; set; }
        public string MediaId { get; set; }
        public bool LikedByMe { get; set; }
        public int Likes { get; set; }
        public bool RePostedByMe { get; set; }
        public int RePosts { get; set; }
        public int Answers { get; set; }

        public void Mapping(Profile profile) {
            int userId = 0;
            
            profile.CreateMap<Post, PostDto>()
                .ForMember(dto => dto.LikedByMe, opt => opt.MapFrom(Post.IsLikedBy(userId)))
                .ForMember(dto => dto.Likes, opt => opt.MapFrom(p => p.Likes.Count()))
                .ForMember(dto => dto.RePostedByMe, opt => opt.MapFrom(Post.IsRePostedBy(userId)))
                .ForMember(dto => dto.RePosts, opt => opt.MapFrom(p => p.RePosts.Count()))
                .ForMember(dto => dto.Answers, opt => opt.MapFrom(p => p.Answers.Count()));
        }
    }
}