namespace Tabloid.Models.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryWithPostsDTO : CategoryDTO
    {
        public List<PostsByCategoryDTO> Posts { get; set; }
    }
}