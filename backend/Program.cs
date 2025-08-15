using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using DotNetEnv;

  var builder = WebApplication.CreateBuilder(args);

  Env.Load();

  var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
var mobileAppUrl = Environment.GetEnvironmentVariable("MOBILE_APP_URL");

  // Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
  builder.Services.AddOpenApi();

if (builder.Environment.IsEnvironment("Testing"))
{
  builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseInMemoryDatabase("Testing"));
}
else
{
  builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
  builder.WebHost.UseUrls(mobileAppUrl ?? "https://localhost:7031;http://localhost:5218"); // !! REMOVE THIS IF PHYSICAL MOBILE TESTING NOT REQUIRED !! //
  builder.Services.AddCors(options =>
  {
    options.AddPolicy(name: "AllowOrigins",
                      policy =>
                      {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
  });
  }

  var app = builder.Build();

  app.UseCors("AllowOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.MapOpenApi();
}


  app.UseCors("AllowOrigins");
  app.MapControllers();
  app.Run();  
  public partial class Program { }