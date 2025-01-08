using Tabloid.Data;
using Tabloid.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
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
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _context.Categories
            .FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Post(Category category)
    {
        _context.Add(category);
        _context.SaveChanges();
        return CreatedAtAction("Get", new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }
        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
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