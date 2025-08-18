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
              new User { Username = "alice", Email = "alice@heybubble.co.nz", Password = "$2a$12$AuEm75i/QjIuF3ZMcvzkCOGtorxfispojQkLnIac0pQgkS6rJ0LdK" },
              new User { Username = "bob", Email = "bob@heybubble.co.nz", Password = "$2a$12$iaPCaJF2IW3S7TnJJqEaDe1hUp0LRVI.HYDCmG20N6xyE9sMrCjv2" }
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