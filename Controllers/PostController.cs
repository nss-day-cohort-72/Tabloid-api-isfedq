using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid_api_isfedq.Controllers;

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
            var post = _DbContext.Posts
            .ProjectTo<AllPostListDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        
        
       
    }

        
