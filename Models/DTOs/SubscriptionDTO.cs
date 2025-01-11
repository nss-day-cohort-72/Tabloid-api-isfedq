using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models.DTOs
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public UserProfileForSubscriptionsDTO Author { get; set; }
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }       
    }
    public class SubscriptionForPostsDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<AllPostListDTO> Posts { get; set; }
    }
}