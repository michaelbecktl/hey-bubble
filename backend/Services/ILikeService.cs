using Backend.Entity;

namespace Backend.Services
{
  public interface ILikeService
  {
    Task<PostLike> AddLikeToPost(int userId, int postId);

    Task<CommentLike> AddLikeToComment(int userId, int commentId);

    Task<bool> DeleteLikeFromPost(int userId, int postId);

    Task<bool> DeleteLikeFromComment(int userId, int commentId);
  }
}