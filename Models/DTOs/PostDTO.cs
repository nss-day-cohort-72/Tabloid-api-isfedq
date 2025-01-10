using Tabloid.Models.DTOs;

namespace Tabloid.Models.DTOs
{
    public class AllPostListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public bool Approved { get; set; }
        public int ReadTime { get; set; }
        public DateTime PublicationDate { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
    }
    public class PostDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool Approved { get; set; }
        public string HeaderImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public int ReadTime { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public List<TagDTO> Tags { get; set; }
        public List<PostReactionDTO> PostReactions { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
        public CategoryDTO Category { get; set; }
    }
    public class AddPostDTO
    {
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string? HeaderImageUrl { get; set; }

    }
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string? HeaderImageUrl { get; set; }

    }
    public class PostsByCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool Approved { get; set; }
        public string HeaderImageUrl { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int ReadTime { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public List<TagDTO> Tags { get; set; }
        public List<PostReactionDTO> PostReactions { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
    }
}