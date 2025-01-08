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
        CreateMap<PostReaction, PostReactionDTO>();
        CreateMap<Reaction, ReactionDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<UserProfile, UserProfileForPostDTO>();
        
  
        
        

    }
        
    
}