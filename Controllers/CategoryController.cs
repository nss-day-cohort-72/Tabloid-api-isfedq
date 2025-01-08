using Tabloid.Data;
using Tabloid.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private TabloidDbContext _context;
    public CategoryController(TabloidDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var categories = _context.Categories;
        List<CategoryWithPostsDTO> categoriesDTO = categories.Select(c => new CategoryWithPostsDTO
        {
            Id = c.Id,
            Name = c.Name,
            Posts = c.Posts.Select(p => new PostsByCategoryDTO
            {
                Id = p.Id,
                Title = p.Title,
                UserProfileId = p.UserProfileId,
                Content = p.Content,
                CategoryId = p.CategoryId,
                Approved = p.Approved,
                HeaderImageUrl = p.HeaderImageUrl,
                
            }).ToList()
            
        }).ToList();
        return Ok(categoriesDTO);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        CategoryDTO categoryDTO = new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name
        };
        if (categoryDTO == null)
        {
            return NotFound();
        }
        return Ok(categoryDTO);
    }

    [HttpPost]
    public IActionResult Post(CategoryDTO categoryDTO)
    {
        Category category = new Category
        {
            Name = categoryDTO.Name
        };
        _context.Add(category);
        _context.SaveChanges();
        return Ok($"{category.Name} with id of {category.Id} was added to the database");
        // return CreatedAtAction("Get", new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CategoryDTO categoryDTO)
    {
        string originalName = categoryDTO.Name;
        if (id != categoryDTO.Id)
        {
            return BadRequest();
        }
        Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        category.Name = categoryDTO.Name;

        _context.SaveChanges();
        return Ok($"Category {originalName} has been changed to {category.Name}");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}