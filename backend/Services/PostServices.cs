using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Entity;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using static UserController;

public class PostService(AppDbContext context, IConfiguration configuration) : IPostService
{

  public async Task<Post[]?> GetPublicPostsAsync()
  {
    var posts = await context.Posts
    .ToArrayAsync();

    return posts;
  }

  public async Task<Post[]?> GetFollowedPostsAsync(string username)
  {
    var posts = await context.Posts
    .Where(post => post.UserId != )
    .ToArrayAsync();

  }

  public async Task<Post[]?> GetUserPostsAsync(string username)
  {

  }

  private async Task<int?> GetUserIdByUsername(string username)
  {
    return await context.Users
    .Where(user => user.Username == username)
    .Select(user => user.Id)
    .FirstOrDefaultAsync();
  }

  private async Task<string?> GetDisplayNameById(int userId)
  {
    return await context.UserProfiles
    .Where(user => user.UserId == userId)
    .Select(user => user.DisplayName)
    .FirstOrDefaultAsync();
  }
}