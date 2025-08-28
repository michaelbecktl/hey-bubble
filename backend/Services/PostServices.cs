using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Entity;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using static UserController;

public class PostService(AppDbContext context) : IPostService
{

  public async Task<PostDTO[]?> GetPublicPostsAsync(int userId)
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
      isLikedByUser = p.PostLikes != null && p.PostLikes.Any(pl => pl.UserId == userId)
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

  public async Task<PostDTO[]?> GetUserPostsAsync(int userId)
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
      isLikedByUser = p.PostLikes != null && p.PostLikes.Any(pl => pl.UserId == userId)
    })
    .ToArrayAsync();

    return posts;
  }

  public async Task<Post> CreateNewPostAsync(int userId, NewPostDTO request)
  {
    var newPost = new Post
    {
      UserId = userId,
      Content = request.Content,
      MediaUrl = request.MediaUrl,
      MediaType = request.MediaType,
      CreatedAt = DateTime.UtcNow
    };

    context.Posts.Add(newPost);
    await context.SaveChangesAsync();

    return newPost;
  }

  public async Task<bool> DeletePostAsync(int userId, int postId)
  {
    var deletedPost = await context.Posts
    .Where(p => p.PostId == postId && p.UserId == userId)
    .ExecuteDeleteAsync();

    return deletedPost > 0;
  }
}