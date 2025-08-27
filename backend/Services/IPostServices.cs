using Backend.Entity;
using static UserController;

namespace Backend.Services
{
  public interface IPostService
  {
    Task<PostDTO[]?> GetPublicPostsAsync();

    // Task<Post[]?> GetFollowedPostsAsync(string username);

    Task<PostDTO[]?> GetUserPostsAsync(int userId);
  }
}