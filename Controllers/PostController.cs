using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        
        private TabloidDbContext _DbContext;
        private readonly IMapper _mapper;
        public PostController(TabloidDbContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_DbContext.Posts.ProjectTo<AllPostListDTO>(_mapper.ConfigurationProvider)
            .Where(p => p.Approved && p.PublicationDate < DateTime.Now )
            .OrderByDescending(p => p.PublicationDate));
        }
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            PostDetailDTO post = _DbContext.Posts
            .ProjectTo<PostDetailDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        public IActionResult Add([FromBody] AddPostDTO post)
        {   
            Post newPost = _mapper.Map<Post>(post);
            newPost.PublicationDate = DateTime.Now;
            newPost.Approved = true;
            _DbContext.Posts.Add(newPost);
            _DbContext.SaveChanges();
            return Created($"api/post/{newPost.Id}", newPost);
        }
        [HttpPut("{id}/addtags")]
        public IActionResult AddTags(int id, [FromBody]  TagsforPostDTO tags)
        {   
            var post = _DbContext.Posts.Include(p => p.Tags).FirstOrDefault(p => p.Id == id);
            List<Tag> Tags = _DbContext.Tags
            .Where(t => tags.Tags.Contains(t.Id)).ToList();
            foreach (var tag in Tags)
            {
                if (!post.Tags.Any(pt => pt.Id == tag.Id))
                {
                    post.Tags.Add(tag);
                }
              
            }
            var tagsToRemove = post.Tags.Where(pt => !tags.Tags.Contains(pt.Id)).ToList();
            foreach (var tag in tagsToRemove)
            {
                post.Tags.Remove(tag);
            }

            _DbContext.SaveChanges();
            return NoContent();
            
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdatePostDTO post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            
            Post dbPost = _DbContext.Posts.Find(id);
            if (dbPost == null)
            {
                return NotFound();
            }
            dbPost.Title = post.Title;
            dbPost.Content = post.Content;
            dbPost.CategoryId = post.CategoryId;
            dbPost.HeaderImageUrl = post.HeaderImageUrl;

            _DbContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Post post = _DbContext.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            _DbContext.Posts.Remove(post);
            _DbContext.SaveChanges();
            return NoContent();
        }
        [HttpGet("getbyuser/{id}")]
        public IActionResult GetPostByUser(int id)
        {
            return Ok(_DbContext.Posts.ProjectTo<AllPostListDTO>(_mapper.ConfigurationProvider)
            .Where(p => p.UserProfileId == id));
        }
        
        
       
    }

        
