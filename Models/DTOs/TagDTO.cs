namespace Tabloid.Models.DTOs
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TagsforPostDTO
    {
        public List<int> Tags { get; set; }
    }
}