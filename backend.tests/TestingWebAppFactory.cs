using Backend.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.UseEnvironment("Testing");

    builder.UseSetting("https_port", "7031");

    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
              d => d.ServiceType ==
                  typeof(DbContextOptions<AppDbContext>));

      if (descriptor != null)
        services.Remove(descriptor);

      services.AddDbContext<AppDbContext>(options =>
          {
            options.UseInMemoryDatabase("Testing");
          });


      var sp = services.BuildServiceProvider();
      using (var scope = sp.CreateScope())
      using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
      {
        try
        {
          appContext.Database.EnsureCreated();

          var aliceUser = new User { Username = "aliceuser", Email = "alice@heybubble.co.nz", Password = "$2a$12$AuEm75i/QjIuF3ZMcvzkCOGtorxfispojQkLnIac0pQgkS6rJ0LdK" };
          var bobUser = new User { Username = "bobuser", Email = "bob@heybubble.co.nz", Password = "$2a$12$iaPCaJF2IW3S7TnJJqEaDe1hUp0LRVI.HYDCmG20N6xyE9sMrCjv2" };
          appContext.Users.AddRange(aliceUser, bobUser);

          appContext.UserProfiles.AddRange(
            new UserProfile
            {
              UserId = aliceUser.Id,
              DisplayName = "Alice",
              Dob = new DateOnly(1995, 5, 12),
              ProfilePhoto = null,
              Gender = "Female",
              Country = "NZ",
              NativeLanguage = "EN",
              LearningLanguage = "JP",
              Following = 10,
              Followers = 25,
            },
            new UserProfile
            {
              UserId = bobUser.Id,
              DisplayName = "Bob",
              Dob = new DateOnly(1992, 9, 3),
              ProfilePhoto = null,
              Gender = "Male",
              Country = "AU",
              NativeLanguage = "EN",
              LearningLanguage = "JP",
              Following = 5,
              Followers = 12,
            }
          );

          appContext.Posts.AddRange(
            new Post
            {
              UserId = aliceUser.Id,
              Content = "Hello world! Excited to start my language learning journey.",
              CreatedAt = DateTime.UtcNow,
              UpdatedAt = null,
              MediaUrl = null,
              MediaType = null,
              LikeCount = 0,
              CommentCount = 0,
            },
            new Post
            {
              UserId = bobUser.Id,
              Content = "Just finished a new tutorial on Japanese verbs. Feeling accomplished!",
              CreatedAt = DateTime.UtcNow,
              UpdatedAt = null,
              MediaUrl = null,
              MediaType = null,
              LikeCount = 0,
              CommentCount = 0,
            }
          );

          appContext.SaveChanges();
        }
        catch (Exception ex)
        {
          Console.Write(ex);
        }
      }
    });
    }
}