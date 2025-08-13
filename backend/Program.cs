using Microsoft.EntityFrameworkCore;
using DotNetEnv;

  var builder = WebApplication.CreateBuilder(args);

  Env.Load();

  var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

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
  }

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
      app.UseDeveloperExceptionPage();
      app.MapOpenApi();
  }

  app.MapControllers();
  app.Run();  
  public partial class Program { }