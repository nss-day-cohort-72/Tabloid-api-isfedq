using AutoMapper;
using Tabloid.Models;
using Tabloid.Models.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        
        CreateMap<Post, PostDTO>();
        CreateMap<UserProfile,UserProfileForPostDTO >();
        
        

    }
        
    
}