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
        Password = "mayatest",
        Email = "maya@heybubble.co.nz",
      },
      new User
      {
        Id = -3,
        Username = "aliceuser",
        Password = "alicetest",
        Email = "alice@heybubble.co.nz",
      },
      new User
      {
        Id = -2,
        Username = "hanauser",
        Password = "hanatest",
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