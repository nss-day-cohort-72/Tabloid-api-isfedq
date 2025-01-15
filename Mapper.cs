using AutoMapper;
using Tabloid.Models;
using Tabloid.Models.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        
        CreateMap<Post, AllPostListDTO>();
        CreateMap<Post, PostDetailDTO>();
        CreateMap<Comment, CommentDTO>();
        CreateMap<Tag,TagDTO >();
        CreateMap<TagDTO, Tag>();
        CreateMap<PostReaction, PostReactionDTO>();
        CreateMap<Reaction, ReactionDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<UserProfile, UserProfileForPostDTO>();
        CreateMap<AddPostDTO, Post >();
        CreateMap<UpdatePostDTO, Post >();
        // CreateMap<Subscription, SubscriptionDTO>();
        CreateMap<Subscription, SubscriptionDTO>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));
        CreateMap<UserProfile, UserProfileForSubscriptionsDTO>()
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts.Where(p => p.Approved && p.PublicationDate < DateTime.Now)));
        CreateMap<Post, PostDTO>();
        
  
        
        

    }
        
    
}