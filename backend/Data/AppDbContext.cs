using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }

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
      }
      );
  }

}