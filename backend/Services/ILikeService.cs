using Backend.Entity;

namespace Backend.Services
{
  public interface ILikeService
  {
    Task<PostLikeDTO> AddLikeToPost(int userId, int postId);

    Task<CommentLikeDTO> AddLikeToComment(int userId, int commentId);

    Task<bool> DeleteLikeFromPost(int userId, int postId);

    Task<bool> DeleteLikeFromComment(int userId, int commentId);
  }
}