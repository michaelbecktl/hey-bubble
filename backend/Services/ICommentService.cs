using Backend.Entity;

namespace Backend.Services
{
  public interface ICommentService
  {
    Task<IEnumerable<CommentDTO>> GetCommentByPostIdAsync(int userId, int postId);

    Task<Comment> CreateNewCommentAsync(int userId, NewCommentDTO request);

    Task<Comment?> UpdateCommentAsync(int userId, int commentId, UpdateCommentDTO request);

    Task<bool> DeleteCommentAsync(int userId, int commentId);
  }
}