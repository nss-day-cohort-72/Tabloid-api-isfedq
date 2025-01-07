using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tabloid.Models;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Data;
public class TabloidDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> PostTags { get; set; }
    public DbSet<Reaction> ReactionPosts { get; set; }
    

    public TabloidDbContext(DbContextOptions<TabloidDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                UserName = "JohnDoe",
                Email = "john@doe.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                UserName = "JaneSmith",
                Email = "jane@smith.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                UserName = "AliceJohnson",
                Email = "alice@johnson.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                UserName = "BobWilliams",
                Email = "bob@williams.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                UserName = "EveDavis",
                Email = "Eve@Davis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
            },

        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                ImageLocation = "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                CreateDateTime = new DateTime(2022, 1, 25)
            },
             new UserProfile
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                CreateDateTime = new DateTime(2023, 2, 2),
                ImageLocation = "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Smith",
                CreateDateTime = new DateTime(2022, 3, 15),
                ImageLocation = "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                CreateDateTime = new DateTime(2023, 6, 10),
                ImageLocation = "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Williams",
                CreateDateTime = new DateTime(2023, 5, 15),
                ImageLocation = "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Davis",
                CreateDateTime = new DateTime(2022, 10, 18),
                ImageLocation = "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
            }
        });
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, Name = "Help" },
            new Category { Id = 2, Name = "Food" },
            new Category { Id = 3, Name = "Animals" },
            new Category { Id = 4, Name = "Misc" },
            new Category { Id = 5, Name = "Vacationing" },
            new Category { Id = 6, Name = "Tech" },
        });
        
        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
            new Tag { Id = 1, Name = "Fun" },
            new Tag { Id = 2, Name = "Sad" },
            new Tag { Id = 3, Name = "Ouch" },
        });

        modelBuilder.Entity<Reaction>().HasData(new Reaction[]
        {
            new Reaction { Id = 1, Name = "👍" },
            new Reaction { Id = 2, Name = "🤢" },
            new Reaction { Id = 3, Name = "🤣" },
            new Reaction { Id = 4, Name = "❤" },
        });

        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post { Id = 1, Title = "Why Does My Cat Bite My Leg?", UserProfileId = 1, Content = "I need help. My cat keeps biting my leg.", CategoryId = 1, HeaderImageUrl = "https://robohash.org/numquamutut.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 1, 7), ReadTime = 50 },
            new Post { Id = 2, Title = "California Raisin", UserProfileId = 2, Content = "Hey! Does anybody remember the California Raisin guy?", CategoryId = 4, HeaderImageUrl = "https://robohash.org/numquamutut.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 1, 4), ReadTime = 30 },
            new Post { Id = 3, Title = "The Future of AI", UserProfileId = 3, Content = "Exploring the advancements in AI technology.", CategoryId = 6, HeaderImageUrl = "https://robohash.org/futureai.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 2, 10), ReadTime = 25 },
            new Post { Id = 4, Title = "Healthy Eating", UserProfileId = 4, Content = "Tips and tricks for a healthier diet.", CategoryId = 2, HeaderImageUrl = "https://robohash.org/healthyeating.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 3, 15), ReadTime = 60 },
            new Post { Id = 5, Title = "Traveling the World", UserProfileId = 5, Content = "A guide to traveling the world on a budget.", CategoryId = 5, HeaderImageUrl = "https://robohash.org/travelworld.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 4, 20), ReadTime = 110 },
            new Post { Id = 6, Title = "Tech Innovations", UserProfileId = 6, Content = "Latest innovations in the tech industry.", CategoryId = 6, HeaderImageUrl = "https://robohash.org/techinnovations.png?size=150x150&set=set1", PublicationDate = new DateTime(2025, 5, 25), ReadTime = 130 },
        });
        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment { Id = 1, PostId = 1, UserProfileId = 1, Subject = "Ouch!", Content = "I'm sorry to hear that. Have you tried giving your cat a toy to play with instead?", CreationDate = new DateTime(2025, 1, 7) },
            new Comment { Id = 2, PostId = 1, UserProfileId = 2, Subject = "Re: Ouch!", Content = "I have! But my cat still prefers my leg.", CreationDate = new DateTime(2025, 1, 8) },
            new Comment { Id = 3 , PostId = 2, UserProfileId = 3, Subject = "California Raisin", Content = "Yes! I remember the California Raisin guy. He was so cool.", CreationDate = new DateTime(2025, 1, 9) },
            new Comment { Id = 4, PostId = 3, UserProfileId = 4, Subject = "AI Technology", Content = "I'm excited to see where AI technology will take us in the future.", CreationDate = new DateTime(2025, 1, 10) },
            new Comment { Id = 5 , PostId = 4, UserProfileId = 5, Subject = "Healthy Eating", Content = "Thanks for the tips! I'll definitely try them out.", CreationDate = new DateTime(2025, 1, 15) },
            new Comment { Id = 6, PostId = 5, UserProfileId = 6, Subject = "Traveling the World", Content = "I've always wanted to travel the world. This guide is really helpful.", CreationDate = new DateTime(2025, 1, 8) },

        });
    }
}