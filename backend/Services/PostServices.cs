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
    .Include(p => p.User)
    .ThenInclude(u => u.UserProfile)
    .Select(p => new PostDTO
    {
      PostId = p.PostId,
      UserId = p.UserId,
      DisplayName = p.User.UserProfile != null ? p.User.UserProfile.DisplayName : string.Empty,
      Content = p.Content,
      CreatedAt = p.CreatedAt,
      UpdatedAt = p.UpdatedAt,
      MediaUrl = p.MediaUrl,
      MediaType = p.MediaType,
      LikeCount = p.LikeCount,
      CommentCount = p.CommentCount,
    })
    .ToArrayAsync();

    return posts;
  }

  // ------- To Update with actual logic after Followers table is created ------- //
  // public async Task<Post[]?> GetFollowedPostsAsync(string username)
  // {
  //   var posts = await context.Posts
  //   .Where(post => post.UserId !=  )
  //   .ToArrayAsync();

  // }

  public async Task<Post[]?> GetUserPostsAsync(int userId)
  {
    var posts = await context.Posts
    .Include(p => p.User)
    .ThenInclude(u => u.UserProfile)
    .Where(p => p.UserId == userId)
    .Select(p => new PostDTO
    {
      PostId = p.PostId,
      UserId = p.UserId,
      DisplayName = p.User.UserProfile != null ? p.User.UserProfile.DisplayName : string.Empty,
      Content = p.Content,
      CreatedAt = p.CreatedAt,
      UpdatedAt = p.UpdatedAt,
      MediaUrl = p.MediaUrl,
      MediaType = p.MediaType,
      LikeCount = p.LikeCount,
      CommentCount = p.CommentCount,
    })
    .ToArrayAsync();

    return posts;
  }
}