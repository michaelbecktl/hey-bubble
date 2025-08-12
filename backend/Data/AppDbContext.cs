using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }

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
  }

}