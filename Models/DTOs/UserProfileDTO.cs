namespace Tabloid.Models.DTOs
{
    public class UserProfileForPostDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        
    }
    public class UserProfileForSubscriptionsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public List<Post> Posts { get; set; }

        
    }

    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageLocation { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsActive { get; set; }
    }
        
}