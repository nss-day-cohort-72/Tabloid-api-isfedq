namespace Tabloid.Models.DTOs
{
    public class AllPostListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public bool Approved { get; set; }
        public DateTime PublicationDate { get; set; }
        public UserProfileForPostDTO UserProfile { get; set; }
    }
}