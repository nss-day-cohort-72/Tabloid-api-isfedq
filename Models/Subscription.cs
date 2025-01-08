using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public UserProfile Author { get; set; }
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public UserProfile Subscriber { get; set; }
        
        public DateTime StartDate { get; set; }
       
    }
}