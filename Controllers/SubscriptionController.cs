using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid.Controllers;

[Route("api/[controller]")]
[ApiController]

public class SubscriptionController : ControllerBase
{
        private readonly TabloidDbContext _DbContext;
        private readonly IMapper _mapper;

        public SubscriptionController(TabloidDbContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }
        //This gets all subscriptions along with associated author's posts
        [HttpGet("get-subscriptions/{subscriberId}")]
        public IActionResult Get(int subscriberId)
        {
            return Ok(_DbContext.Subscriptions.ProjectTo<SubscriptionDTO>(_mapper.ConfigurationProvider)
            .Where(s => s.SubscriberId == subscriberId && s.EndDate == null));
            // List<SubscriptionDTO> subscriptions = _DbContext.Subscriptions
            // .Where(s => s.SubscriberId == subscriberId && s.EndDate == null)
            // .Select(s => new SubscriptionDTO
            // {
            //     Id = s.Id,
            //     AuthorId = s.AuthorId,
            //     Author = new UserProfileForSubscriptionsDTO
            //     {
            //         Id = s.Author.Id,
            //         FirstName = s.Author.FirstName,
            //         LastName = s.Author.LastName,
            //         FullName = s.Author.FullName,
            //         Posts = s.Author.Posts
            //         .Where(p => p.Approved && p.PublicationDate < DateTime.Now)
            //         .Select(p => new Post
            //         {
            //             Id = p.Id,
            //             Title = p.Title,
            //             Content = p.Content,
            //             UserProfileId = p.UserProfileId,
            //             CategoryId = p.CategoryId,
            //             Approved = p.Approved,
            //             Category = p.Category,
            //             Tags = p.Tags,
            //             Comments = p.Comments,
            //             PostReactions = p.PostReactions
            //         }).ToList()
            //     },
            //     SubscriberId = s.SubscriberId,
            //     StartDate = s.StartDate,
            //     EndDate = s.EndDate
            // }).ToList();
            // return Ok(subscriptions);
        }
        [HttpPost]
        public IActionResult Add(SubscriptionDTO subscriptionDTO)
        {
            var authorExists = _DbContext.UserProfiles.Any(u => u.Id == subscriptionDTO.AuthorId);
            var subscriberExists = _DbContext.UserProfiles.Any(u => u.Id == subscriptionDTO.SubscriberId);
            var existingSubscription = _DbContext.Subscriptions.FirstOrDefault(s => s.AuthorId == subscriptionDTO.AuthorId && s.SubscriberId == subscriptionDTO.SubscriberId);

            if (!authorExists || !subscriberExists)
            {
                return BadRequest(new { Message = "Invalid AuthorId or SubscriberId" });
            }

            if (existingSubscription != null)
            {
                if (existingSubscription.EndDate == null)
                {
                    return BadRequest(new { Message = "Subscription already exists" });
                }
                else
                {
                    existingSubscription.EndDate = null;
                    existingSubscription.StartDate = DateTime.Now;
                    _DbContext.SaveChanges();
                    return Ok(existingSubscription);
                }
            }

            Subscription subscription = new Subscription()
            {
                AuthorId = subscriptionDTO.AuthorId,
                SubscriberId = subscriptionDTO.SubscriberId,
                StartDate = DateTime.Now
            };
            _DbContext.Subscriptions.Add(subscription);
            _DbContext.SaveChanges();
            return Created($"api/subscription/{subscription.Id}", subscription);
        }

        [HttpGet("check-subscription/{authorId}/{subscriberId}")]
        public IActionResult Check(int authorId, int subscriberId)
        {
            Subscription subscription = _DbContext.Subscriptions
                .FirstOrDefault(s => s.AuthorId == authorId &&
                 s.SubscriberId == subscriberId &&
                 s.EndDate == null);
            if (subscription == null)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpPut("delete/{authorId}/{subscriberId}")]
        public IActionResult SoftDelete(int authorId, int subscriberId)
        {
            Subscription subscription = _DbContext.Subscriptions
                .FirstOrDefault(s => s.AuthorId == authorId && s.SubscriberId == subscriberId);
            if (subscription == null)
            {
                return NotFound();
            }
            subscription.EndDate = DateTime.Now;
            // _DbContext.Subscriptions.Remove(subscription);
            _DbContext.SaveChanges();
            return Ok(new { message = "Subscription removed" });
        }

        //This is to allow hard deleting from the database through Swagger, etc, for testing
        [HttpDelete("delete/{id}")]
        public IActionResult HardDelete(int id)
        {
            Subscription subscription = _DbContext.Subscriptions
                .FirstOrDefault(s => s.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }
            subscription.EndDate = DateTime.Now;
            _DbContext.Subscriptions.Remove(subscription);
            _DbContext.SaveChanges();
            return Ok(new { message = "Subscription removed" });
        }

        
}