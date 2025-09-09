
using Backend.Entity;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

public class LikeService(AppDbContext context) : ILikeService
{

  public async Task<PostLikeDTO> AddLikeToPost(int userId, int postId)
  {
    var newLike = new PostLike
    {
      PostId = postId,
      UserId = userId
    };

    var post = await context.Posts
    .Where(p => p.PostId == postId)
    .FirstOrDefaultAsync();

    context.PostLikes.Add(newLike);
    if (post != null) post.LikeCount++;

    await context.SaveChangesAsync();

    return new PostLikeDTO
    {
      PostId = newLike.PostId,
      UserId = newLike.UserId  
    };
  }

  public async Task<CommentLikeDTO> AddLikeToComment(int userId, int commentId)
  {
    var newLike = new CommentLike
    {
      CommentId = commentId,
      UserId = userId
    };

    var comment = await context.Comments
    .Where(c => c.CommentId == commentId)
    .FirstOrDefaultAsync();

    if (comment != null) comment.LikeCount++;
    context.CommentLikes.Add(newLike);
    await context.SaveChangesAsync();

    return new CommentLikeDTO
    {
      CommentId = newLike.CommentId,
      UserId = newLike.UserId  
    };
  }

  public async Task<bool> DeleteLikeFromPost(int userId, int postId)
  {
    var deletedLike = await context.PostLikes
    .Where(pl => pl.PostId == postId && pl.UserId == userId)
    .ExecuteDeleteAsync();

    var post = await context.Posts.Where(p => p.PostId == postId).FirstOrDefaultAsync();
    if (post != null && deletedLike > 0) post.LikeCount--;
    await context.SaveChangesAsync();

    return deletedLike > 0;
  }

  public async Task<bool> DeleteLikeFromComment(int userId, int commentId)
  {
    var deletedLike = await context.CommentLikes
    .Where(pl => pl.CommentId == commentId && pl.UserId == userId)
    .ExecuteDeleteAsync();

    var comment = await context.Comments.Where(p => p.CommentId == commentId).FirstOrDefaultAsync();
    if (comment != null && deletedLike > 0) comment.LikeCount--;
    await context.SaveChangesAsync();

    return deletedLike > 0;
  }
}