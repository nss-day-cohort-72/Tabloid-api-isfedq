using System.ComponentModel;

namespace Tabloid.Models;

public class Post 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }
    public bool Approved { get; set; }
    public Category Category { get; set; }
    public string HeaderImageUrl { get; set; }
    public DateTime PublicationDate { get; set; }
    public int ReadTime { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Tag> Tags { get; set; }
    public List<PostReaction> PostReactions { get; set; }
}
