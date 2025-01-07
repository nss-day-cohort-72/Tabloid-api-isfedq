namespace Tabloid.Models.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserProfileId { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
    }
}