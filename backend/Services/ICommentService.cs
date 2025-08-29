using Backend.Entity;

namespace Backend.Services
{
  public interface ICommentService
  {
    Task<IEnumerable<CommentDTO>> GetCommentByPostIdAsync(int userId, int postId);

    Task<Comment> CreateNewComment(int userId, NewCommentDTO request);
  }
}