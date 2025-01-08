using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid_api_isfedq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TabloidDbContext _dbContext;
        private readonly IMapper _mapper;

        public TagController(TabloidDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _dbContext.Tags
                .ProjectTo<TagDTO>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync();

            return Ok(tags);
        }

        // GET: api/Tag/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var tag = await _dbContext.Tags
                .ProjectTo<TagDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // CREATE/POST: api/Tag
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagDTO tagDto)
        {
            if (string.IsNullOrWhiteSpace(tagDto.Name))
            {
                return BadRequest("Tag name is required.");
            }

            var tag = _mapper.Map<Tag>(tagDto);
            _dbContext.Tags.Add(tag);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetails), new { id = tag.Id }, _mapper.Map<TagDTO>(tag));
        }

        // UPDATE/PUT: api/Tag/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TagDTO tagDto)
        {
            if (id != tagDto.Id)
            {
                return BadRequest("Tag ID mismatch.");
            }

            var existingTag = await _dbContext.Tags.FindAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            existingTag.Name = tagDto.Name;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Tag/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _dbContext.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}


