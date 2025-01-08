namespace Tabloid.Models.DTOs
{
    public class CreateCommentDto
    {
        public int PostId { get; set; } // Links the comment to a specific post
        public string Subject { get; set; }
        public string Content { get; set; }
    }

}