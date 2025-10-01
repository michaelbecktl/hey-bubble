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
              appContext.Users.AddRange(
              new User { Id = 1, Username = "aliceuser", Email = "alice@heybubble.co.nz", Password = "$2a$12$AuEm75i/QjIuF3ZMcvzkCOGtorxfispojQkLnIac0pQgkS6rJ0LdK" },
              new User { Id = 2, Username = "bobuser", Email = "bob@heybubble.co.nz", Password = "$2a$12$iaPCaJF2IW3S7TnJJqEaDe1hUp0LRVI.HYDCmG20N6xyE9sMrCjv2" }
              );

              appContext.UserProfiles.AddRange(
                new UserProfile
                {
                  UserId = 1,
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
                  UserId = 2,
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
                  PostId = 1,
                  UserId = 1,
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
                  PostId = 2,
                  UserId = 2,
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