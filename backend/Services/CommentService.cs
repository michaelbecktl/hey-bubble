using Backend.Entity;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

public class CommentService(AppDbContext context) : ICommentService
{
  public async Task<IEnumerable<CommentDTO>> GetCommentByPostIdAsync(int userId, int postId)
  {
    var comments = await context.Comments
    .Include(c => c.User)
    .ThenInclude(u => u.UserProfile)
    .Where(c => c.PostId == postId)
    .Select(c => new CommentDTO
    {
      CommentId = c.CommentId,
      PostId = c.PostId,
      UserId = c.UserId,
      DisplayName = c.User.UserProfile != null ? c.User.UserProfile.DisplayName : string.Empty,
      Content = c.Content,
      CreatedAt = c.CreatedAt,
      UpdatedAt = c.UpdatedAt,
      MediaUrl = c.MediaUrl,
      MediaType = c.MediaType,
      LikeCount = c.LikeCount,
      isLikedByUser = c.CommentLike != null && c.CommentLike.Any(cl => cl.UserId == userId)
    })
    .ToListAsync();

    return comments;
  }

  public async Task<Comment> CreateNewComment(int userId, NewCommentDTO request)
  {
    var newComment = new Comment
    {
      UserId = userId,
      PostId = request.PostId,
      Content = request.Content,
      MediaUrl = request.MediaUrl,
      MediaType = request.MediaType,
      CreatedAt = DateTime.UtcNow
    };

    context.Comments.Add(newComment);
    await context.SaveChangesAsync();

    return newComment;
  }
}