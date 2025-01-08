using Tabloid.Models.DTOs;

namespace Tabloid.Models.DTOs
{
    public class PostReactionDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserProfileId { get; set; }
        public int ReactionId { get; set; }
        public ReactionDTO Reaction { get; set; }
    }
}