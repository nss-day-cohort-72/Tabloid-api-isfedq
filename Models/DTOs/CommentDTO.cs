namespace Tabloid.Models.DTOs;

    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string Subject { get; set; }
        public int UserProfileId { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
        public DateTime CreationDate { get; set; }
    }
