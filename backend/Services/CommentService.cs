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

  public async Task<CommentDTO> CreateNewCommentAsync(int userId, NewCommentDTO request)
  {
    var post = await context.Posts
      .Where(p => p.PostId == request.PostId)
      .FirstOrDefaultAsync();

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
    if (post != null) post.CommentCount++;
    
    await context.SaveChangesAsync();

    return new CommentDTO
    {
      PostId = newComment.PostId,
      UserId = newComment.UserId,
      Content = newComment.Content,
      CreatedAt = newComment.CreatedAt,
      MediaUrl = newComment.MediaUrl,
      MediaType = newComment.MediaType,
    };
  }

  public async Task<Comment?> UpdateCommentAsync(int userId, int commentId, UpdateCommentDTO request)
  {
    var comment = await context.Comments
    .FirstOrDefaultAsync(c => c.CommentId == commentId && c.UserId == userId);

    if (comment == null) return null;

    comment.Content = request.Content;
    comment.UpdatedAt = DateTime.UtcNow;

    await context.SaveChangesAsync();

    return comment;
  }

  public async Task<bool> DeleteCommentAsync(int userId, int commentId)
  {
    var deletedComment = await context.Comments
    .Where(c => c.CommentId == commentId && c.UserId == userId)
    .ExecuteDeleteAsync();

    return deletedComment > 0;
  }
}