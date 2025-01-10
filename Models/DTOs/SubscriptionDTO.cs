using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }
}