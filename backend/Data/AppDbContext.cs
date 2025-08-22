using Backend.Entity;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }

  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>().HasData(
      new User
      {
        Id = -1,
        Username = "mayauser",
        Password = "$2a$12$J8d2vGlMWUiW6dWIszp2F.rzAw7qBYq5Hbd/6ijGX5o6x3Q5oX2G2",
        Email = "maya@heybubble.co.nz",
      },
      new User
      {
        Id = -3,
        Username = "aliceuser",
        Password = "$2a$11$fzXCnjrZ3KKnm3nI1nbdm.XQjaF3x/mXUIcmWMe3r2dMjBsSuRQ7u",
        Email = "alice@heybubble.co.nz",
      },
      new User
      {
        Id = -2,
        Username = "hanauser",
        Password = "$2a$12$kMngNi/lnbyCxnixyC7Swuq99AWEvm9YGk8M.y9uneD49W3wJqvWm",
        Email = "hana@heybubble.co.nz",
      }
    );

    modelBuilder.Entity<UserProfile>()
    .HasOne(up => up.User)
    .WithOne(u => u.UserProfile)
    .HasForeignKey<UserProfile>(up => up.UserId);

    modelBuilder.Entity<UserProfile>().HasData(
      new UserProfile
      {
        UserId = -1,
        DisplayName = "Maya",
        Dob = new DateOnly(1991, 12, 6),
        ProfilePhoto = null,
        Gender = "Female",
        Country = "NZ",
        NativeLanguage = "EN",
        LearningLanguage = "JP",
        Following = 1,
        Followers = 1,
      },
      new UserProfile
      {
        UserId = -2,
        DisplayName = "Alice",
        Dob = new DateOnly(1991, 07, 2),
        ProfilePhoto = null,
        Gender = "Female",
        Country = "NZ",
        NativeLanguage = "EN",
        LearningLanguage = "JP",
        Following = 0,
        Followers = 1,
      },
      new UserProfile
      {
        UserId = -3,
        DisplayName = "Hana",
        Dob = new DateOnly(2001, 01, 31),
        ProfilePhoto = null,
        Gender = "Female",
        Country = "NZ",
        NativeLanguage = "JP",
        LearningLanguage = "EN",
        Following = 2,
        Followers = 1,
      }
      );

    var postSeed = new[]
    {
      new Post
      {
        PostId = 1,
        UserId = -1,
        Content = "Hi everyone! Welcome to Bubble!",
        CreatedAt = new DateTime(2025, 8, 20, 9, 56, 0),
        UpdatedAt = null
      },
      new Post
      {
        PostId = 2,
        UserId = -3,
        Content = "Ohayo everyone! Nice to meet you!",
        CreatedAt = new DateTime(2025, 8, 20, 10, 12, 0),
        UpdatedAt = null
      },
    };

    modelBuilder.Entity<Post>()
    .HasOne(p => p.User)
    .WithMany(u => u.Posts)
    .HasForeignKey(p => p.UserId)
    .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Post>().HasData(postSeed);

    var commentSeeds = new[]
    {
      new Comment
      {
        PostId = 1,
        CommentId = 1,
        UserId = -3,
        Content = "Hi!",
        CreatedAt = new DateTime (2025, 8, 20, 10, 9, 0)
      },
      new Comment
      {
        PostId = 1,
        CommentId = 2,
        UserId = -2,
        Content = "Hey there!",
        CreatedAt = new DateTime (2025, 8, 20, 10, 16, 0)
      }
    };

    modelBuilder.Entity<Comment>()
    .HasOne(c => c.User)
    .WithMany(u => u.Comments)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Comment>()
    .HasOne(c => c.Post)
    .WithMany(p => p.Comments)
    .HasForeignKey(c => c.PostId)
    .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Comment>().HasData(commentSeeds);

    modelBuilder.Entity<PostLike>()
    .HasOne(pl => pl.User)
    .WithMany(u => u.PostLikes)
    .HasForeignKey(pl => pl.UserId)
    .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<PostLike>()
    .HasOne(pl => pl.Post)
    .WithMany(p => p.PostLikes)
    .HasForeignKey(pl => pl.PostId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<CommentLike>()
    .HasOne(cl => cl.User)
    .WithMany(u => u.CommentLike)
    .HasForeignKey(cl => cl.UserId)
    .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<CommentLike>()
    .HasOne(cl => cl.Comment)
    .WithMany(c => c.CommentLike)
    .HasForeignKey(cl => cl.CommentId)
    .OnDelete(DeleteBehavior.Restrict);
    
  }

}