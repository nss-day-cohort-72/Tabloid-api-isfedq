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
        //This get all subscriptions is only for testing in Swagger
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_DbContext.Subscriptions);
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