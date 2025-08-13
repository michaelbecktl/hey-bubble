using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class HeyBubbleWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
        d => d.ServiceType == typeof(DbContextOptions<AppDbContext>)
      );

      if (descriptor != null)
        services.Remove(descriptor);

      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseInMemoryDatabase("TestDb");
      });

      using var scope = services.BuildServiceProvider().CreateScope();
      var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
      db.Database.EnsureCreated();
    });
    }
}