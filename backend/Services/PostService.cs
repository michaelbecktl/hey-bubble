
using Backend.Entity;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

public class PostService(AppDbContext context) : IPostService
{

  public async Task<IEnumerable<PostDTO>?> GetPublicPostsAsync(int userId)
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
    .ToListAsync();

    return posts;
  }

  // ------- To Update with actual logic after Followers table is created ------- //
  // public async Task<Post[]?> GetFollowedPostsAsync(string username)
  // {
  //   var posts = await context.Posts
  //   .Where(post => post.UserId !=  )
  //   .ToArrayAsync();

  // }

  public async Task<IEnumerable<PostDTO>?> GetUserPostsAsync(int userId)
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
    .ToListAsync();

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

  public async Task<Post?> UpdatePostAsync(int userId, int postId, UpdatePostDTO request)
  {
    var post = await context.Posts
    .FirstOrDefaultAsync(p => p.PostId == postId && p.UserId == userId);

    if (post == null) return null;

    post.Content = request.Content;
    post.UpdatedAt = DateTime.UtcNow;

    await context.SaveChangesAsync();

    return post;
  }


  public async Task<bool> DeletePostAsync(int userId, int postId)
  {
    var deletedPost = await context.Posts
    .Where(p => p.PostId == postId && p.UserId == userId)
    .ExecuteDeleteAsync();

    return deletedPost > 0;
  }
}