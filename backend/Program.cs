using Microsoft.EntityFrameworkCore;
using DotNetEnv;

public class Program
{ 
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    Env.Load();

    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.MapControllers();
    app.Run();

  }
}